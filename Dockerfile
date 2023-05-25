FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install --global dotnet-ef
WORKDIR /src
COPY src/Api/Api.csproj Api/
COPY src/Core/Core.csproj Core/
COPY src/Startup/Startup.csproj Startup/
WORKDIR /src/Startup
RUN dotnet restore

WORKDIR /src
COPY src/ .

WORKDIR /src/Startup
RUN dotnet build "Startup.csproj" -c Release -o /app/build --no-restore
RUN dotnet publish "Startup.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
EXPOSE 80
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Startup.dll"]