var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var podName = Environment.GetEnvironmentVariable("POD_NAME") ?? "pod-desconhecido";

app.MapGet("/", () => $"teste kubernetes ia Pod: {podName}");

app.Run();