using LexiconLMS.Server;
using LexiconLMS.Server.Data;
using LexiconLMS.Server.Extensions;
using LexiconLMS.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;
using LexiconLMS.Server.MyModels;
using Microsoft.Extensions.DependencyInjection;

namespace LexiconLMS.Server
{
    public /*static*/ class Program
    {
        /*public static void Main*/
        /* async Task */
        /*public static void*/
        public static async Task Main(string[] args, IServiceProvider serviceProvider)
        {
            //IServiceProvider serviceProvider = new();
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            //builder.Services.AddAutoMapper(typeof(Program));

            // Make sure we have the database
            serviceProvider.GetService<ApplicationDbContext>().Database.EnsureCreated();
        

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            //builder.MyModels.MockDataService();
            var app = builder.Build();

            //await app;

            //var scope = app.ApplicationServices.CreateScope();
            //var serviceProvider = scope.ServiceProvider;
            //var db = serviceProvider.GetRequiredService<ApplicationDbContext>();

            ////db.Database.EnsureDeleted();
            ////db.Database.Migrate();

            ////dotnet user-secrets set "AdminPW" "BytMig123!"
            //var config = serviceProvider.GetRequiredService<IConfiguration>();
            //var adminPW = config["AdminPW"];

            //await app.SeedDataAsync();

            //MockDataService.ApplicationUsers();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthorization();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();

            //await builder.Build().RunAsync();

        }
    }
}