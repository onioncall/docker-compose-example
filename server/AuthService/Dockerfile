# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file and project files
COPY ["AuthService.sln", "./"]
COPY ["TestSite.AuthService.Api/*.csproj", "TestSite.AuthService.Api/"]
COPY ["TestSite.AuthService.Domain/*.csproj", "TestSite.AuthService.Domain/"]
COPY ["TestSite.AuthService.Persistence/*.csproj", "TestSite.AuthService.Persistence/"]
COPY ["TestSite.AuthService.Contract/*.csproj", "TestSite.AuthService.Contract/"]

# Restore dependencies
RUN dotnet restore "./AuthService.sln"

# Copy entire solution
COPY . .

# Build the project
WORKDIR "/src/TestSite.AuthService.Api"
RUN dotnet build "TestSite.AuthService.Api.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "TestSite.AuthService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published artifacts from previous stage
COPY --from=publish /app/publish .

# Expose the port your app runs on (adjust as needed)
EXPOSE 8082
EXPOSE 8083
ENV ASPNETCORE_URLS=http://+:8082

# Set the entry point for the application
ENTRYPOINT ["dotnet", "TestSite.AuthService.Api.dll"]
