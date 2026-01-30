var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "teste k8s windows");

app.Run();
