using BlazorWebAssemblyProjectTest.Server.DB;
using BlazorWebAssemblyProjectTest.Shared;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssemblyProjectTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //SqlServerDbContextFactory sqlServerDbContextFactory = new SqlServerDbContextFactory();
            //SqlServerDbContext context = sqlServerDbContextFactory.CreateDbContext(new string[0]);

            //foreach(var ansver in context.Answers)
            //    {
            //        ansver.Name
            //    };

            // Add services to the container.

            var connString = "Server=(localdb)\\mssqllocaldb;Database=TestDatabase123;Trusted_Connection=True;";
            builder.Services.AddDbContext<SqlServerDbContext>(opt => opt.UseSqlServer(connString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            }));

            builder.Services.AddControllers();
            //builder.Services.AddControllersWithViews();
            //builder.Services.AddRazorPages();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI();
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


            //app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}
