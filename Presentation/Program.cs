using System.Text.Json.Serialization;
using crispy_winner.infrastructure.context;
using FinancialApi.Applications;
using FinancialApi.Domain.Interfaces;
using FinancialApi.Domain.Services;
using FinancialApi.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<FinancialsService>();
builder.Services.AddScoped<BudgetService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TransactionsService>();
builder.Services.AddScoped<CategoryService>();


//Inject interfaces
builder.Services.AddScoped<IUserRepository, UsersRepository>();
builder.Services.AddScoped<IBudgetRespository, BudgetRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); //!add controllers to the services + allow enums to be lowercased and accepted into JSON response

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
