using BL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MadmounMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using EmailService;
using MadmounMobileApp.Controllers;

using MadmounMobileApp.Helpers;
using MadmounMobileApp.Services;

namespace MadmounMobileApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var emailConfig = Configuration
          .GetSection("EmailConfiguration")
          .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddControllersWithViews().AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddScoped<CityService, ClsCity>();
            services.AddScoped<AreaService, ClsArea>();
            services.AddScoped<ServiceCategoryService, ClsServiceCategories>();
            services.AddScoped<ServiceService, ClsService>();
            services.AddScoped<ComplainService, ClsComplains>();
            services.AddScoped<LogInHistoryService, ClsLoginHistory>();
            services.AddScoped<ServicesRequiredService, ClsServicesRequired>();
            services.AddScoped<ServicesApprovedService, ClsServicesApproved>();
            services.AddScoped<ServiceApprovedImagesService, ClsServiceApprovedImages>();
            services.AddScoped<ServiceApprovedMilstoneService, ClsServiceApprovedMilstone>();
            services.AddScoped<SrOffService, ClsSrOffService>();
            services.AddScoped<SrrepService, ClsSrRepService>();
            services.AddScoped<SrrepCityService, ClsSrRepCity>();
            services.AddScoped<SroffCityService, ClsSrOffCity>();
            services.AddScoped<CleintService, ClsClients>();
            services.AddScoped<ClientImagesService, ClsClientImages>();
            services.AddScoped<AdvertismentService, ClsAdvertisments>();
            services.AddScoped<AdviceService, ClsAdvice>();
            services.AddScoped<ServicesOfferService, ClsServicesOffers>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<LastDevelopmentService, ClsLastDevelopment > ();
            services.AddScoped<TransactionService, ClsTransaction>();
            services.AddScoped<IGetChat, ClsGetPayment>();
            services.AddScoped<IGetServiceApproved, ClsGetServiceApproved>();
           
            //services.Configure<SMSOptions>(Configuration);


            services.Configure<TwilioSettings>(Configuration.GetSection("Twilio"));
            services.AddTransient<ISMSService, SMSService>();


            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder => {
                    //URLs are from the front-end (note that they changed
                    //since posting my original question due to scrapping
                    //the original projects and starting over)
                    builder.WithOrigins("https://localhost:44398/", "http://ismguk.com/")
                                     .AllowAnyHeader()
                                     .AllowAnyMethod()
                                     .AllowCredentials();
                });
            });
            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddDbContext<MadmounDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;

            }).AddErrorDescriber<CustomIdentityErrorDescriber>().AddEntityFrameworkStores<MadmounDbContext>().AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/User/AccessDenied";
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = "/User/LogIn";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;


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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(

               name: "areas",
               pattern: "{area:exists}/{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
