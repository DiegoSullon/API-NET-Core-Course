using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiRoutesResponses.Services;
using WebApiRoutesResponses.MiddleWares;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApiRoutesResponses.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
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
            services.AddControllers(config =>
            {
                config.EnableEndpointRouting = false;
                //var policy = new AuthorizationPolicyBuilder()
                //                .RequireAuthenticatedUser()
                //                .Build();
                //config.Filters.Add(new AuthorizeFilter(policy));
            }).AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            // services.AddScoped<IUserDataService,UserDataService>();//nuueva instancia por cada request
            // services.AddSingleton<IUserDataService,UserDataService>();//única instancia
            services.AddTransient<IUserDataService, UserDataService>();//nueva instancia por cada inyeccion de dependencia
            services.AddCors(p =>
            {
                p.AddPolicy("MyPolicy",
                builder =>
                {
                    builder.AllowAnyHeader()
                    .WithOrigins("http://127.0.0.1:5501")
                    .WithMethods("GET", "POST")
                    .Build();
                });
            });

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretKey"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {

                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateLifetime =  true,
                        ValidIssuer = "",
                        ValidAudience = "",
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey= true
                    };
            });
            // services.AddDbContext<ApiAppContext>(options =>
            //     options.UseInMemoryDatabase("AppDB"));
            services.AddDbContext<ApiAppContext>(options =>
                options.UseSqlServer(@"Data Source=DESKTOP-FV5LUU9\SQLEXPRESS;Initial Catalog=EDteamApi;Integrated Security=SSPI;"));
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseCors("MyPolicy");

            // app.UseHttpsRedirection();

            // app.UseCors(builder =>
            // {
            //     builder.AllowAnyHeader()
            //     .WithOrigins("http://127.0.0.1:5501")
            //     .WithMethods("GET", "POST")
            //     .Build();
            // });

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGet("/myroot", async context =>
                {
                    await context.Response.WriteAsync("Holaa desde my root");
                });
            });
            app.UseWelcomePage();
            app.UseStatusMiddleWare();
            // app.Run(async context=>{
            //     await context.Response.WriteAsync("URL no encontrada");
            // });
        }
    }
}
