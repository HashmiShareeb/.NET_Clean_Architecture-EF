var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Test Application Running");

app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));


app.Run("http://localhost:5000");
