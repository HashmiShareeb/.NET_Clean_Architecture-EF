using crispy_winner.infrastructure.context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //!add controllers to the services

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

//! add dbcontext to services
// builder.Services.AddDbContext<ApplicationContext>(
//     options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"))
// );
builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), // The connection string
        ServerVersion.AutoDetect // Automatically detect the MySQL server version
        (builder.Configuration.GetConnectionString("DefaultConnection")) // Needed so EF Core can generate compatible SQL
    )
);





var app = builder.Build();

app.MapGet("/", () => "Financial Management API is running...");

app.MapControllers(); //!only way to make controller work

app.Run("http://localhost:5000");
