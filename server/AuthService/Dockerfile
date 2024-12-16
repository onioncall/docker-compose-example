FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file and project files
COPY ["AuthService/AuthService.sln", "./"]
COPY ["AuthService/TestSite.AuthService.Api/*.csproj", "./TestSite.AuthService.Api/"]
COPY ["AuthService/TestSite.AuthService.Domain/*.csproj", "./TestSite.AuthService.Domain/"]  
COPY ["AuthService/TestSite.AuthService.Persistence/*.csproj", "./TestSite.AuthService.Persistence/"]
COPY ["TestSite.Contracts/*.csproj", "../TestSite.Contracts/"]

# Restore dependencies
RUN dotnet restore "AuthService.sln"

# Copy everything else
COPY ["AuthService/", "./"]
COPY ["TestSite.Contracts/", "../TestSite.Contracts/"]

# Build the project
WORKDIR "/src/TestSite.AuthService.Api"
RUN dotnet build "TestSite.AuthService.Api.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "TestSite.AuthService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8082
EXPOSE 8083

# Set the entry point for the application
ENTRYPOINT ["dotnet", "TestSite.AuthService.Api.dll"]
