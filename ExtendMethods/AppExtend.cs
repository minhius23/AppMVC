using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace App.ExtendMethods
{
    public static class AppExtends
    {
        public static void AddStatusCodePage(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(appError =>
            {
                appError.Run(async context =>
                {
                    var response = context.Response;
                    var code = response.StatusCode;
                    var content = @$"<html>
                        <head>
                           <meta charset='UTF-8' />
                           <title>Error {code}</title>
                        </head>
                        <body>
                           <p style='color: red; font-size: 30px'>
                              Có Lỗi Xảy Ra {code} - {(HttpStatusCode)code}
                           </p>
                        </body>
                    </html>";
                    await response.WriteAsync(content); 
                });
            });
        }
    }
}
