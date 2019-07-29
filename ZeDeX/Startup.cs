using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;
using ZeDeX.DI;

namespace ZeDeX
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
                            config.Filters.Add(typeof(ValidateModelStateAttribute)))
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(options =>  options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Zedex API",
                    Version = "v1",
                    Description = "A partner CRUD",
                    Contact = new Contact
                    {
                        Name = "João Freitas",
                        Url = "https://github.com/jgabrielfreitas/"
                    }
                });
            });

            DependencyInjection.Inject(_configuration, services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(action =>
            {
                action.SwaggerEndpoint("/swagger/v1/swagger.json", "Zedex");
                action.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        public class ValidateModelStateAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (!context.ModelState.IsValid)
                {


                    var invalidProperties = GetInvalidProperties(context);
                    context.Result = new BadRequestObjectResult(new { InvalidProperties = invalidProperties });
                }
            }

            private static IEnumerable<InvalidProperty> GetInvalidProperties(ActionExecutingContext context)
            {
                var result = new List<InvalidProperty>();

                foreach (var state in context.ModelState)
                {
                    var invalidProperty = new InvalidProperty();
                    invalidProperty.Name = state.Key;
                    invalidProperty.Details = state.Value.Errors.Select(p => p.ErrorMessage);
                    result.Add(invalidProperty);
                }
                return result;
            }

            private class InvalidProperty
            {
                public string Name { get; set; }
                public object Details { get; set; }
            }
        }
    }
}
