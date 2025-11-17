var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); //!add controllers to the services
var app = builder.Build();

app.MapGet("/", () => "Test Application Running");

app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));

app.MapControllers(); //!only way to make controller work

app.Run("http://localhost:5000");
