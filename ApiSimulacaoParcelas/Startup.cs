using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Domain.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repository;

namespace ApiSimulacaoParcelas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }
      

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyOrigin();
                });

                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod(); 
                    
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(opt => opt
                    .UseSqlServer(Configuration.GetConnectionString("BancoSimulacao"))
            );

            services.AddTransient<ISimulacaoCompraRepository, SimulacaoCompraRepository>();
            services.AddTransient<IParcelaCompraRepository, ParcelaCompraRepository>();

            services.AddTransient<ISimulacaoCompraBusiness, SimulacaoCompraBusiness>();
            services.AddTransient<IParcelaCompraBusiness, ParcelaCompraBusiness>();
            services.AddTransient<JsonMessage, JsonMessage>();



            services.Configure<MvcOptions>(options => {
                options.Filters.Add(new CorsAuthorizationFilterFactory("_myAllowSpecificOrigins"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IServiceProvider serviceProvider)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(MyAllowSpecificOrigins);
            // app.UseCors(option => option.WithOrigins(""));
            // app.UseCors(option => option.AllowAnyMethod());
            // app.UseCors(option => option.AllowAnyHeader());
            app.UseHttpsRedirection();
            ////app.UseCors(option => option.AllowAnyOrigin()
            //.AllowAnyMethod()
            //.AllowAnyHeader());
            app.UseMvc();
            serviceProvider.GetService<Context>().Database.EnsureCreated();
        }
    }
}
