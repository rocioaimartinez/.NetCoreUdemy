using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module1.Data;
using Module1.Services;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;

namespace Module1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //to change the request/response format: Add.Mvc().AddXmlSerializerFormatters
            
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddDbContext<ProductBDContext>(option => option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Products;"));
            //UseSqlServer(Configuration.GetConnectionString("ProductBDContext"));
            //services.AddApiVersioning();
            services.AddScoped<IProduct, ProductRepository>();
            //services.AddSwaggerGen(c => c.SwaggerDoc());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Products API", Version = "v1" });
            });
            //MvcOptions ops = new MvcOptions();
            //ops.EnableEndpointRouting = false;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ProductBDContext productBDContext)
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

        app.UseHttpsRedirection();
        productBDContext.Database.EnsureCreated();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API");
        });
        app.UseMvc();
            
            
        }
    }
}
