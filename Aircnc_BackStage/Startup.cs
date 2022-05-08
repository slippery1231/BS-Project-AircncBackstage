using Aircnc_BackStage.Common.Coraval;
using Aircnc_BackStage.Common.Schudule;
using Aircnc_BackStage.Helpers;
using Aircnc_BackStage.Models;
using Aircnc_BackStage.Repositories.Interface;
using Aircnc_BackStage.Repositories.Redis;
using Aircnc_BackStage.Services;
using AircncFrontStage.Repositories;
using Coravel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aircnc_BackStage
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
            services.AddControllersWithViews();
            services.AddDbContext<AircncContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AircncContext"));

            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(
                  option =>
                  {
                      option.IncludeErrorDetails = true;

                      option.TokenValidationParameters = new TokenValidationParameters
                      {
                          ValidateIssuer = true,
                          ValidIssuer = JwtHelper.Issuer,
                          ValidateAudience = false,
                          ValidateLifetime = true,
                          IssuerSigningKey = JwtHelper.SecurityKey
                              
                      };

                  });
            //註冊REdis
            services.AddStackExchangeRedisCache(options =>
            options.Configuration = Configuration["RedisConfig:ToolManMemoryCache"]);
            //µù¥U Swagger ªA°È
            services.AddSwaggerDocument();
            //repository
            services.AddTransient<DBRepository, DBRepository>();
            services.AddTransient<IMemoryCacheRepository, MemoryCacheRepository>();
            //Add service
            services.AddTransient<GetDataService, GetDataService>();
            services.AddTransient<GetUserService, GetUserService>();
            services.AddTransient<GetTransactionDataService, GetTransactionDataService>();
            //排程
            services.AddScheduler();

            services.AddTransient<UpdateChartDataRedisTask>();
            services.AddTransient<UpdatePieDataRedisTask>();
            services.AddTransient<UpdateOrderStatusDaily>();
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
            //排程
            app.ApplicationServices.UseScheduler(scheduler => {
                scheduler.Schedule<UpdateChartDataRedisTask>().Hourly();
                scheduler.Schedule<UpdatePieDataRedisTask>().Hourly();
                scheduler.Schedule<UpdateOrderStatusDaily>().DailyAt(0, 1);
            });

            app.UseHttpsRedirection();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
