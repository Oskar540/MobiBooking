using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using MobiBooking.Models;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MobiBooking.Models.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using MobiBooking.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MobiBooking
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
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddDbContext<BookingDbContext>(opts =>
            //opts.UseSqlServer(Configuration["Data:MobiBookingDb:ConnectionString"]));
            opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            #region JWT Auth
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
        });
            #endregion


            services.AddMvc();
            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
           });

            #region Identity

            // services.AddIdentity<ApplicationUser, IdentityRole>()
            //.AddEntityFrameworkStores<BookingDbContext>()
            //.AddDefaultTokenProviders();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;

                // Lockout settings
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;


                // SignIn settings
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            })
    .AddEntityFrameworkStores<BookingDbContext>()
    .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "MobiBookingCookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                //options.LoginPath = "/Account/Login";
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
                            ctx.Response.StatusCode == (int)StatusCodes.Status200OK)
                        {
                            ctx.Response.StatusCode = (int)StatusCodes.Status401Unauthorized;
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                        return Task.FromResult(0);
                    }
                };
                // ReturnUrlParameter requires `using Microsoft.AspNetCore.Authentication.Cookies;`
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //CreateRoles(serviceProvider).Wait();

            app.UseMvc();
        }

//        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
//        {

//            //adding customs roles
//            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//            string[] roleNames = { "Admin", "Manager", "Member" };
//            IdentityResult roleResult;
//​
//            foreach (var roleName in roleNames)
//            {
//                // creating the roles and seeding them to the database
//                var roleExist = await RoleManager.RoleExistsAsync(roleName);
//                if (!roleExist)
//                {
//                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
//                }
//            }
//​
//            // creating a super user who could maintain the web app
//            var poweruser = new ApplicationUser
//            {
//                UserName = Configuration.GetSection("AppSettings")["UserEmail"],
//                Email = Configuration.GetSection("AppSettings")["UserEmail"]
//            };
//​
//            string userPassword = Configuration.GetSection("AppSettings")["UserPassword"];
//            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("AppSettings")["UserEmail"]);
//​
//            if (user == null)
//            {
//                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
//                if (createPowerUser.Succeeded)
//                {
//                    // here we assign the new user the "Admin" role 
//                    await UserManager.AddToRoleAsync(poweruser, "Admin");
//                }
//            }
//        }
    }
}
