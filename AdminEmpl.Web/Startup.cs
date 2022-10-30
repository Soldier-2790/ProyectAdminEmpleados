using AdminEmpl.Servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminEmpl.Web
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
            services.AddRazorPages();
            //Añadimos la referencia al servicio referente a los empleados
            //Previamente debimos conectar las bibliotecas de clases estática
            //services.AddSingleton<IEmpleadoRepo,MapEmpleadoRepo>();
            //Ponemos el servicio del repositorio con EntityFramework
            services.AddScoped<IEmpleadoRepo, SQLEmpleadoRepo>();
            //Añadimos el servicio de routing o rutas
            //RouteOptions usa Microsoft.AspNetCore.Routing para ser llamado
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
                //Añadimos la restricción del ruteo
                options.ConstraintMap.Add("even", typeof(EventRestrinc));
            });
            //Aplicamos la cadena de texto y la conexión a la base de datos
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EmpleadoBDConex"));
            });
            //Cuando nos conectamos a la base de datos debemos abrir lo siguiente:
            //Consola de administrador de paquetes
            //Ponemos el comando SQLLocalDB.exe i nos mostrará información sobre las bases de datos que tiene SQLLocalDB.exe
            //Luego seleccionamos una instancia con el siguiente comando SQLLocalDB.exe start [NombreInstacia]
            //Debemos seleccionar el proyecto en donde se encuentre los servicios que usas
            //Luego iniciamos la migración con el comando add-Migrationo InitialCreate, al ejecutarlo se nos agrega una carpeta llamada Migrations
            //Gracias a la libreria de Entitu Framework no debemos hacer mucho esfuerzo en crear la base de datos ya que tiene una opción llamada Code-First
            //Para aplicar la configuración de la base de datos usamos el comando Update-Database y se debería crear la base de datos
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
