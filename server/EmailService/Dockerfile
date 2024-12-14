FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file and project files
COPY ["EmailService/EmailService.sln", "./"]
COPY ["EmailService/TestSite.EmailService.Api/*.csproj", "./TestSite.EmailService.Api/"]
COPY ["EmailService/TestSite.EmailService.Domain/*.csproj", "./TestSite.EmailService.Domain/"]  
COPY ["EmailService/TestSite.EmailService.Persistence/*.csproj", "./TestSite.EmailService.Persistence/"]
COPY ["TestSite.Contracts/*.csproj", "../TestSite.Contracts/"]

# Restore dependencies
RUN dotnet restore "EmailService.sln"

# Copy everything else
COPY ["EmailService/", "./"]
COPY ["TestSite.Contracts/", "../TestSite.Contracts/"]

# Build the project
WORKDIR "/src/TestSite.EmailService.Api"
RUN dotnet build "TestSite.EmailService.Api.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "TestSite.EmailService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8086
EXPOSE 8087

# Set the entry point for the application
ENTRYPOINT ["dotnet", "TestSite.EmailService.Api.dll"]
