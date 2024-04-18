
using Microsoft.EntityFrameworkCore;

namespace YandexRasp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<RaspModelDbContext>(options =>
        {
            options.UseLazyLoadingProxies().UseSqlServer("Data Source=127.0.0.1,1433;Initial Catalog=RaspDatabase;User ID=sa;Password=Passlogin1;TrustServerCertificate=True;App=EntityFramework");
        });
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
