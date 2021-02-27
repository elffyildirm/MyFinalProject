using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
            //Autofac,Ninject,CastWindsor,StructureMap, LightInject,DryInject... bunlar dot.net projelerinde  kendi i�in �os yap�s� yokken bu �ekilde �al��mak isteyenler i�in ortamlar sunuyor -->IoC Container
            //AOP bir methodun �n�nde sonunda method hata verdi�inde �al�san kod par�ac�klar� aop mimarisiyle yaz�l�r yani business i�inde business �al�s�r
            //Postsharp
            services.AddControllers();
            //services.AddSingleton<IProductService, ProductManager>();   //bana arka planda bir referans olu�tur   //buras� arka planda sizin i�in new ler //i�inde data yoksa singleton yap
            //services.AddSingleton<IProductDal, EfProductDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
