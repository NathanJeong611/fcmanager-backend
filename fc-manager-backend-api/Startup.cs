using System.Runtime.Serialization;
using fc_manager_backend_abstraction;
using fc_manager_backend_repository;
using fc_manager_backend_da.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Newtonsoft.Json;


namespace fc_manager_backend_api
{
    public class Startup
    {
        private string CORSOriginName = "FCMangerOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            // Add databas3e
            services.AddDbContext<FCMContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<ILeagueRepository, LeagueRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<ICodeRepository, CodeRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IMatchRecordRepository, MatchRecordRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers().AddNewtonsoftJson(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );

        services.AddCors(options =>
        {
            options.AddPolicy(CORSOriginName,
            builder =>
            {
                builder.WithOrigins("http://localhost:3000",
                                    "https://fcmanager-frontend.herokuapp.com/",
                                    "http://fcmanager-frontend.herokuapp.com/"
                )
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                        //https://fcmanager-frontend.herokuapp.com/
            });
        });


        services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(CORSOriginName); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
