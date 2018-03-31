using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using propellerhead.CommandHandlers;
using propellerhead.Commands;
using propellerhead.Data;
using propellerhead.Implementations;
using propellerhead.Interfaces;
using propellerhead.Queries;
using propellerhead.QueryHandlers;

namespace propellerhead
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
            RegisterGenerics(services);
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("CustomDB"));
            services.AddMvc();
            
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private void RegisterGenerics(IServiceCollection services)
        {
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<INotesRepository, NotesRepository>();
            services.AddScoped<IQueryHandler<GetCustomersQuery, IEnumerable<Customer>>, GetCustomersQueryHandler>();
            services.AddScoped<IQueryHandler<GetCustomerQuery, Customer>, GetCustomerQueryHandler>();
            services.AddScoped<ICommandHandler<UpdateCustomerStatusCommand>, UpdateCustomerStatusCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteNoteCommand>, DeleteNoteCommandHandler>();
            services.AddScoped<ICommandHandler<AddNoteCommand>, AddNoteCommandHandler>();
        }
    }
}
