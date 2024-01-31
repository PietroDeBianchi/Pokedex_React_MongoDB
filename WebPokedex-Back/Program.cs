
using WebPokedex.Models;
using WebPokedex.Services;


namespace WebPokedex
{
    // min xx:xx video => https://www.youtube.com/watch?v=ZNnNhInTKxI
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // CORS Configuration
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000") // Sostituisci con il tuo indirizzo frontend
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // * read DB Settings in appsettings.json
            builder.Services.Configure<DatabaseSet>(
                builder.Configuration.GetSection("MyDB")
                );
            // * Add Transient Settings from Services - resolving the loginservice dependency in LoginController
            builder.Services.AddTransient<ILoginServices, LoginServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Allow specific Origins for CORS policy
            app.UseCors("AllowSpecificOrigin");

            app.MapControllers();

            app.Run();
        }
    }
}