using System.Reflection.Metadata.Ecma335;

namespace IngressoMinimalApi.AppServicesExtensions
{
    public static class ApplicationBuilderExtensions
    {
        //TRATAMENTO DE EXCESSÃO.
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app,
            IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            return app;
        }

        //HABILITANDO O CORS.
        public static IApplicationBuilder UseAppCors(this IApplicationBuilder app)
        {
            app.UseCors(p =>
            {
                p.AllowAnyOrigin();
                p.WithMethods("GET");
                p.AllowAnyHeader();
            });
            return app;
        }

        //HABILITANDO O MIDDLEWARE DO SWAGGER.
        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { });
            return app;
        }
        
    }
}
