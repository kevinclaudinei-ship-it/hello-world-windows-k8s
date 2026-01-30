var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World from Windows Container on Kubernetes 🚀");

app.Run();
