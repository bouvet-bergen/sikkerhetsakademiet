using Microsoft.AspNetCore.Antiforgery;

namespace Sikkerhetsakademiet.Configuration
{
    public static class CsrfTokenForSpaConfiguration
    {
        public static void UseCustomCsrfTokenForSpa(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            var service = services.GetRequiredService<IAntiforgery>();

            app.Use(async (context, next) =>
            {
                var tokenSet = service.GetAndStoreTokens(context);
                var token = tokenSet.RequestToken;
                if (token != null)
                {
                    context.Response.Cookies.Append("XSRF-TOKEN", token, new CookieOptions
                    {
                        Path = "/",
                        HttpOnly = false
                    });
                }
                await next();
            });
        }

    }
}
