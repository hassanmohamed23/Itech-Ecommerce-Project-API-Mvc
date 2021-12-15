using EbayAdminDbContext;
using EbayAdminModels.Category;
using EbayAdminModels.SubCategory;
using EbayAdminRepository.Brands;
using EbayAdminRepository.Category;
using EbayAdminRepository.Comments;
using EbayAdminRepository.Offers;
using EbayAdminRepository.Orders;
using EbayAdminRepository.Products;
using EbayAdminRepository.Rates;
using EbayAdminRepository.Shippers;
using EbayAdminRepository.Stocks;
using EbayAdminRepository.SubCategory;
using EbayAdminRepository.WatchLists;
using EbayAdminRepository.Admins;
using EbayAdminRepository.Users; 
using EbayView.Controllers.UploadImg;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using EbayAdminRepository.Homes;
using EbayView.Services;
using EbayAdminModels;
using Microsoft.AspNetCore.Identity;
using System;

namespace EbayView
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
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IWatchListRepository, WatchListRepository>();
            services.AddTransient<IRateRepository, RateRepository>();
            services.AddTransient<IShipperRepository, ShipperRepository>();
            services.AddTransient<IOfferRepository, OfferRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IHomeRepository, HomeRepository>();
            // mapping between class MainSetting and appsettings.json
            services.Configure<MailSetting>(Configuration.GetSection("EmailSettings"));
            services.Configure<AzureStorage>(Configuration.GetSection("AzureStorage")); 
            services.AddTransient<IMailServices, MailServices>();

            // For Identity  
            services.AddIdentity<User, UserRoles>()
                .AddEntityFrameworkStores<myDbContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();

             services.AddSingleton<UploadImgController>();// for upload img 
            //services.AddScoped<UploadImgController>();// for upload img 
            //services.AddTransient<UploadImgController>();


            services.AddControllersWithViews();
            services.AddSession();
            //Added for session state
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
            });
            services.AddDbContext<myDbContext>
                (options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
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
            ///Session
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                // Products   Home  Categories Accounts  Login   Index
            });
        }

    }
}
