using Microsoft.EntityFrameworkCore;
using Rekrutacja_170125.DatabaseContext;
using Rekrutacja_170125.Entities;

namespace Rekrutacja_170125
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Connection string from configuration
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Context registration
            builder.Services.AddDbContext<ShopContext>(options =>
                options.UseSqlServer(connectionString));


            // Add services to the container.
            builder.Services.AddRazorPages();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.MapControllers();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
