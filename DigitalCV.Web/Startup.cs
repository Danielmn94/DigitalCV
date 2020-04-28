using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DigitalCV.Data.Domain;
using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using DigitalCV.Data.Repositories;
using DigitalCV.Service.Services;
using DigitalCV.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using DigitalCV.Data.Helpers;

namespace DigitalCV.Web
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
            services.AddDbContext<DigitalCVContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DigitalCVConnection")));

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DigitalCVContext>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IEducationService, EducationService>();
            services.AddTransient<IWorkExperienceService, WorkExperienceService>();
            services.AddTransient<IComputerTechnologyService, ComputerTechnologyService>();
            services.AddTransient<ILangaugeService, LanguageService>();
            services.AddTransient<ICertificateService, CertificateService>();

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepositoy<>));

            services.AddTransient<Logger>();

            services.AddHttpContextAccessor();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = $"/Identity/Login";
                options.LogoutPath = $"/Identity/Logout";
                options.AccessDeniedPath = $"/Identity/AccessDenied";
            });

            services.AddControllersWithViews();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
                    name: "default",
                    pattern: "{controller=Identity}/{action=Login}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
