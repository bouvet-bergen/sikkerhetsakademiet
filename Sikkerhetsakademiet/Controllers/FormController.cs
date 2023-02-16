using Microsoft.AspNetCore.Mvc;
using Sikkerhetsakademiet.Models;
using Sikkerhetsakademiet.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Xml;

namespace Sikkerhetsakademiet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private FormDbContext _context;

        public FormController(FormDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]/")]
        public ActionResult<List<Form>> GetAllForms()
        {
            return _context.Forms.ToList();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<Form> GetForm(int id)
        {
            return _context.Forms.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public ActionResult<List<Form>> GetFormsByName(string name)
        {
            string query = $"SELECT * FROM Forms WHERE Name LIKE '%{name}%'";
            return _context.Forms.FromSqlRaw(query).ToList();
        }

        [HttpGet]
        [Route("[action]/")]
        // https://localhost:5176/api/Form/ResetDB
        public ActionResult<List<Form>> ResetDB()
        {
            if (Request.HttpContext.Connection.RemoteIpAddress != null && Request.HttpContext.Connection.RemoteIpAddress.Equals(Request.HttpContext.Connection.LocalIpAddress))
            {
                var useragent = Request.Headers.UserAgent.ToList();
                // Since this workshop is done locally, we cannot use localhost as a barrier, therefore we add useragent check to simulate localhost restriction
                if (useragent.Contains("localhost looking for profileimage plz"))
                {
                    var query = "DELETE FROM Forms";
                    try
                    {
                        _context.Forms.FromSqlRaw(query);
                        return StatusCode((int)HttpStatusCode.OK, "database reset");
                    }
                    catch (Exception ex)
                    {
                        return new List<Form>();
                    }
                }
            }
            return StatusCode((int)HttpStatusCode.Forbidden, "Users may not reset the database");
        }

        [HttpGet]
        [Route("[action]/{sort}")]
        public ActionResult<List<Form>> GetAllFormsWithSort(string sort)
        {
            var query = "SELECT * FROM Forms ORDER BY Name " + sort;
            try
            {
                return _context.Forms.FromSqlRaw(query).ToList();
            }
            catch (Exception ex)
            {
                return new List<Form>();
            }
        }

        [HttpGet]
        [Route("[action]/{url}")]
        public ActionResult GetProfileImage(string url)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var realURI = Uri.UnescapeDataString(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(realURI);
            request.UserAgent = "localhost looking for profileimage plz";
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string responseText = reader.ReadToEnd();

            return Content(responseText);
        }

        [HttpGet]
        [HttpPost]
        [Route("[action]/")]
        public async Task<ActionResult<List<Form>>> LoadXML(XMLForm form)
        {
            XmlDocument doc = new XmlDocument();
            doc.XmlResolver = new XmlUrlResolver();
            doc.LoadXml(form.Message);

            XmlNodeList nodeList = doc.GetElementsByTagName("message");

            string output = "Your processed XML message: ";
            foreach (XmlNode node in nodeList)
            {
                output += node.InnerText;
            }
            
            return new List<Form>
            {
                new Form
                {
                    Name = "XML Processor",
                    Message = output
                }
            };
        }

        [HttpPost]
        public async Task<ActionResult<Form>> PostForm(Form form)
        {
            _context.Forms.Add(form);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetForm), new { id = form.Id }, form);
        }
    }
}