FROM mcr.microsoft.com/dotnet/aspnet:9.0-windowsservercore-ltsc2019 AS base
WORKDIR /app

# 🔑 ESSENCIAL para Kubernetes / Gateway
ENV ASPNETCORE_URLS=http://0.0.0.0:8080

EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0-windowsservercore-ltsc2019 AS build
WORKDIR /src
COPY src/ .
RUN dotnet publish -c Release -o /out

FROM base
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "HelloWorldApi.dll"]
