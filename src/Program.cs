var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var podName = Environment.GetEnvironmentVariable("POD_NAME") ?? "pod-desconhecido";

app.MapGet("/", () => $"teste k8s windows Pod: {podName}");

app.Run();