using LearnCore.Data;
using LearnCore.Repository;
using LearnCore.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LearnCore.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace LearnCore
{
    public class Program  
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddTransient<IEmailSender, EmailSender>();
          
       
            // Seeding the interface of repository

            // builder.Services.AddTransient(typeof(IRepository<>),typeof(MainRepository<>));

            // Seeding the interface of Unit of Work to make the program deal  with one DbContext

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // in cause i use a area and this area have a same name of controller index and home controller

            app.MapControllerRoute(
             name: "area",
             pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

            // To turn on pages od Identity 

            app.UseEndpoints(endpoints =>endpoints.MapRazorPages());

            app.Run();
        }
    }
}
