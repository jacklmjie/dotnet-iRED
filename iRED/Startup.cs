using iRED.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.TagHelpers.LayUI;

namespace iRED
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFrameworkService();
            services.AddLayui();
            services.AddHttpClient("wx", c =>
            {
                c.BaseAddress = new Uri("https://api.weixin.qq.com");
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            services.Configure<WxSettings>(Configuration.GetSection("Wx"));
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            RegisterJwt(services);
            RegisterSwagger(services);
        }

        private void RegisterJwt(IServiceCollection services)
        {
            var jwtOption = Configuration.GetSection("Jwt").Get<JwtSettings>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                string secret = jwtOption.Secret;
                if (string.IsNullOrEmpty(secret))
                {
                    throw new Exception("配置文件中配置的Jwt节点的Secret不能为空");
                }

                jwt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = jwtOption.Issuer,
                    ValidAudience = jwtOption.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)),
                    LifetimeValidator = (before, expires, token, param) => expires > DateTime.Now,
                    ValidateLifetime = true
                };
            });
        }

        private void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                //Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.xml").ToList().ForEach(file =>
                //{
                //    options.IncludeXmlComments(file);
                //});
                //权限Token
                options.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "请输入带有Bearer的Token，形如 “Bearer {Token}” ",
                    Name = "Authorization",
                    In = "header"
                });
                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>()
                {
                    { "Bearer", Enumerable.Empty<string>() }
                });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var configs = scope.ServiceProvider.GetRequiredService<Configs>();
                if (configs.IsQuickDebug == true)
                {
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    });
                }
            }
            app.UseFrameworkService();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
