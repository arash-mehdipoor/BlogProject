using Blog.Application.Users.Commands.RegisterUser;
using Blog.Domain.Articles.Repositories;
using Blog.Domain.Roles.Entities;
using Blog.Domain.Users.Entities;
using Blog.Helpers.Articles;
using Blog.Infrastructure.Articles.Services;
using Blog.Infrastructure.Common;
using Blog.Models.Articles.MappingProfile;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Blog
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
            services.AddControllersWithViews().AddFluentValidation(fv =>
            fv.RegisterValidatorsFromAssemblyContaining<RegisterUserCommand>()); ;

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = "/Account/login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.User.AllowedUserNameCharacters = null;
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(10);
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
                .AddEntityFrameworkStores<BlogDatabaseContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Author", policy =>
                {
                    policy.RequireClaim("Author");
                });
                options.AddPolicy("IsBlogForUser", policy =>
                {
                    policy.AddRequirements(new BlogForUserRequirement());
                });
                //options.AddPolicy("GoldenAuthor", policy =>
                //{
                //    policy.Requirements.Add(new GoldenAuthorRequerment(10));
                //});
            });

            services.AddDbContext<BlogDatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BlogDb"));
            });
            services.AddMediatR(typeof(RegisterUserCommand).Assembly);
            services.AddTransient<IArticleRepasitory, ArticleRepasitory>();
            services.AddAutoMapper(typeof(EditArticleMappingProfile));


            //services.AddScoped<IClaimsTransformation, AddClaim>();
            //services.AddSingleton<IAuthorizationHandler, GoldenAuthorRequermentHandler>();
            services.AddSingleton<IAuthorizationHandler, IsBlogForUserAuthorizationHandler>();
        }

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "areas",
                  pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


            });
        }
    }
}
