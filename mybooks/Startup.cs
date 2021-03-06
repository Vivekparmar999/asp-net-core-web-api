using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using mybooks.Data.Services;
using mybooks.Excep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks
{
    public class Startup
    {

        // 1 adding Connection String props

        public string ConnectionString { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //2 adding COnnection String
            ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //3 Configure DbCOntext with SQl
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

            //configure the services
            services.AddTransient<BooksService>();
            services.AddTransient<AuthorsService>();
            services.AddTransient<PublisshersService>();
            services.AddTransient<LogsService>();

            services.AddApiVersioning(config => {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;

                //Http version
                //config.ApiVersionReader = new HeaderApiVersionReader("custom-version-number");
                config.ApiVersionReader = new MediaTypeApiVersionReader();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "mybooks_updated_title", Version = "v2" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "mybooks_ui_updated v2"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Excption Handling
             app.ConfigureBuildInExceptionHandler(loggerFactory);

            //app.ConfigureCustomExceptionHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Data.AppDbInitalizer.Seed(app);
        }
    }
}
