using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.WebBlazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Presentation.WebBlazor;
using Syncfusion.Blazor;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;



namespace Presentation.WebBlazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<EFAccess>(options =>          //Jimmy
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddSyncfusionBlazor(); //Jimmy

            //JAG TROR ALLT NEDAN SKALL RENSAS BORT. DET ENDA SOM SKALL VARA HÄR, ÄR SÅDANT SOM BEHÖVS PÅ FLERA STÄLLEN.

            //Singleton objects are the same for every object and every request
            services.AddSingleton<Presentation.WebBlazor.ComponentCreation.NumericTextBoxComponents>(); //JIMMY
            services.AddSingleton<Application.UseCases.NumericTextBoxUseCases>(); //JIMMY

            services.AddSingleton<Presentation.WebBlazor.ComponentCreation.ButtonComponents>(); //JIMMY
            services.AddSingleton<Application.UseCases.ButtonUseCases>(); //JIMMY

            services.AddSingleton<Presentation.WebBlazor.ComponentCreation.RangeSliderComponents>(); //JIMMY
            services.AddSingleton<Application.UseCases.RangeSliderUseCases>(); //JIMMY

            services.AddSingleton<Presentation.WebBlazor.ComponentCreation.ParagraphComponents>(); //JIMMY


            services.AddSingleton<Application.Controllers.PictureService>(); //JIMMY

            MyInit myInit = new MyInit();
            //services.AddSingleton<Application.Controllers.PictureController>();



            



            //services.AddSingleton<TreeViewComponents>(); //JIMMY

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            
        }
    }
}
