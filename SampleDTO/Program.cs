using SampleDTO.Endpoints;
using SampleDTO.Middleware;
using SampleDTO.Repositories;
using Scalar.AspNetCore;

namespace SampleDTO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddOpenApi();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.WithTitle("Sample DTO")
                           .WithDownloadButton(true)
                           .WithTheme(ScalarTheme.Purple)
                           .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
                });
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/", () => Results.Redirect("/scalar/v1"));
            app.MapProductEndpoints();

            app.Run();
        }
    }
}
