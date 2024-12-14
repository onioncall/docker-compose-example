FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file and project files
COPY ["ProductService/ProductService.sln", "./"]
COPY ["ProductService/TestSite.ProductService.Api/*.csproj", "./TestSite.ProductService.Api/"]
COPY ["ProductService/TestSite.ProductService.Domain/*.csproj", "./TestSite.ProductService.Domain/"]  
COPY ["ProductService/TestSite.ProductService.Persistence/*.csproj", "./TestSite.ProductService.Persistence/"]
COPY ["TestSite.Contracts/*.csproj", "../TestSite.Contracts/"]

# Restore dependencies
RUN dotnet restore "ProductService.sln"

# Copy everything else
COPY ["ProductService/", "./"]
COPY ["TestSite.Contracts/", "../TestSite.Contracts/"]

# Build the project
WORKDIR "/src/TestSite.ProductService.Api"
RUN dotnet build "TestSite.ProductService.Api.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "TestSite.ProductService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "TestSite.ProductService.Api.dll"]