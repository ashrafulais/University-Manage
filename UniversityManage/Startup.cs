using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UniversityManage.Data;
using UniversityManage.Data.Interfaces;
using UniversityManage.Data.Repositories;
using UniversityManage.Data.Services;

namespace UniversityManage
{
    public class Startup
    {
        public static IContainer AutofacContainer;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionstring, migrarationassemblyname;
            connectionstring = Configuration.GetConnectionString("DefaultConnection");
            migrarationassemblyname = typeof(Startup).Assembly.FullName;

            //var builder = new ContainerBuilder();
            //builder.Populate(services);

            //autofac
            //builder.RegisterType<IUnitofWork>().As<UnitofWork>()
            //    .WithParameter("connectionString", connectionstring)
            //    .WithParameter("migrationAssemblyName", migrarationassemblyname)
            //    .InstancePerLifetimeScope();

            services.AddTransient<IUnitofWork>(x => new UnitofWork(connectionstring, migrarationassemblyname));

            services.AddTransient( s=> new UniversityContext(connectionstring, migrarationassemblyname));

            services.AddDbContext<UniversityContext>(s => s.UseSqlServer( connectionstring,
                m => m.MigrationsAssembly(migrarationassemblyname)));


            //autofac
            //builder.RegisterType<IDepartmentsRepo>().As<DepartmentsRepo>();
            //builder.RegisterType<IDepartmentsService>().As<DepartmentsService>();
            services.AddTransient<IDepartmentsRepo, DepartmentsRepo>()
                .AddTransient<IDepartmentsService, DepartmentsService>();

            services.AddTransient<IStudentsRepo, StudentsRepo>()
                .AddTransient<IStudentsService, StudentsService>();

            services.AddTransient<ICoursesRepo, CoursesRepo>()
                .AddTransient<ICoursesService, CoursesService>();

            services.AddTransient<IInstructorRepo, InstructorRepo>()
                .AddTransient<IInstructorService, InstructorService>();

            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );

            });
        }
    }
}
