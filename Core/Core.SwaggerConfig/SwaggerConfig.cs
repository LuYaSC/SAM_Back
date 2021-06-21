using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace SAM.Core.SwaggerConfig
{
    public class SwaggerConfig : ISwaggerConfig
    {
        private SwaggerConfig(IServiceCollection services, IConfiguration configuration)
        {
            this.services = services;
            this.configuration = configuration;
        }

        public static SwaggerConfig Configure(IServiceCollection services, IConfiguration configuration)
        {
            var _this = new SwaggerConfig(services, configuration);
            _this.Configure();
            return _this;
        }

        public IServiceCollection services { get; set; }

        public IConfiguration configuration { get; set; }

        public void Configure()
        {
            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc(configuration.GetSection("SwaggerConfig")["Version"], new OpenApiInfo
                {
                    Version = configuration.GetSection("SwaggerConfig")["Version"],
                    Title = configuration.GetSection("SwaggerConfig")["Title"],
                    Description = configuration.GetSection("SwaggerConfig")["DescriptionDocumentation"]
                });

                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });
        }
    }
}
