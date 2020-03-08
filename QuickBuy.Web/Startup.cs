using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuickBuy.Repositorio.Contexto;
using QuickBuy.Repositorio;
using Microsoft.EntityFrameworkCore;
using QuickBuy.Repositorio.Repositorios;
using QuickBuy.Dominio.Contratos;

namespace QuickBuy.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            //Instanciado um arquivo de configuracao para conexao com o BD - aki
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json", optional:false, reloadOnChange: true);

            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            /*
             * var connectionString = Configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<QuickBuyContexto>(option =>
                                                        option.UseMySql(connectionString,
                                                                            m => m.MigrationsAssembly("QuickBuy.Repositorio")));
            */
            /*
             * Variavel "QuickBuyBD" está no arquivo config.json
             * "UseLazyLoadingProxies" Pertmite carregamento de forma automatica dos relacionamentos
             *      Ex: O usuario tem pedido, Quando consultar o usuario, faz o carregamento de todos os pedidos ligados a ele automaticamente
             */
            var connectionString = Configuration.GetConnectionString("QuickBuyBD");
            services.AddDbContext<QuickBuyContexto>(option => 
                                                        option
                                                            .UseLazyLoadingProxies()
                                                            .UseSqlServer(connectionString, 
                                                                                s => s.MigrationsAssembly("QuickBuy.Repositorio")));
            
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.UseAngularCliServer(npmScript: "start"); //teste aki
                    /*
                     * Endereco onde esta publicado o projeto de Angular
                     * 
                     */
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200/");
                }
            });
        }
    }
}
