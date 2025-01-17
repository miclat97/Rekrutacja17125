using Microsoft.EntityFrameworkCore;
using Rekrutacja_170125.DatabaseContext;

namespace Rekrutacja_170125
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Pobranie connection string z konfiguracji
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Rejestracja kontekstu bazy danych
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

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
