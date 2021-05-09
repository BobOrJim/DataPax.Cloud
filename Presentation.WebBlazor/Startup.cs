using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Presentation.WebBlazor;
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

            services.AddDbContext<EFAccessCam1KeepTable>(options =>          
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddDbContext<EFAccessCam2KeepTable>(options =>          
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddDbContext<EFAccessIODeviationTable>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddDbContext<EFAccessIOKeepTable>(options =>          
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddSingleton<Presentation.WebBlazor.ComponentCreation.NumericTextBoxComponents>(); 
            services.AddSingleton<Presentation.WebBlazor.ComponentCreation.ButtonComponents>(); 
            services.AddSingleton<Presentation.WebBlazor.ComponentCreation.RangeSliderComponents>(); 
            services.AddSingleton<Presentation.WebBlazor.ComponentCreation.ParagraphComponents>(); 
            services.AddSingleton<Presentation.WebBlazor.ComponentCreation.ImgSrcComponents>(); 
            services.AddSingleton<Presentation.WebBlazor.ComponentCreation.TreeViewComponents>(); 
            services.AddSingleton<Presentation.WebBlazor.ComponentCreation.ClickableListComponents>(); 
            services.AddSingleton<Presentation.WebBlazor.ComponentCreation.DropDownMenuComponents>(); 
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
