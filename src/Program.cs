var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "teste de aplicação k8s em worker windows!!! 🚀");

app.Run();

