namespace Sikkerhetsakademiet.Configuration
{
    public static class ReponseHeadersConfiguration
    {
        public static void UseHttpReponseHeaders(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                AddHeader(context, "CustomHeader", "CustomHeaderValue");
                await next();
            });
        }

        private static void AddHeader(HttpContext context, string key, string value)
        {
            if (context.Response.Headers.ContainsKey(key)) return;

            context.Response.Headers.Add(key, value);
        }
    }
}
