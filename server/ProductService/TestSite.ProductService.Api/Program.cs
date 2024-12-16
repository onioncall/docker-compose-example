using System.Text;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TestSite.MemberService.Persistence.Contexts;
using TestSite.ProductService.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("TestSiteCore");
builder.Services.AddDbContext<TestSiteCoreContext>(opt =>
	opt
		.UseNpgsql(connString)
		.UseSnakeCaseNamingConvention());

builder.Services.AddCors(o => o.AddPolicy("Policy", builder =>
{
	builder.AllowAnyOrigin()
	.AllowAnyHeader()
	.AllowAnyMethod();
}));

var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
	x.RequireHttpsMetadata = false;
	x.SaveToken = true;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(key),
		ValidateIssuer = false,
		ValidateAudience = false
	};
});

string hostname = builder.Configuration.GetSection("RabbitMQ:Host").Value ?? "rabbitmq";
string rabbitUsername = builder.Configuration.GetSection("RabbitMQ:Username").Value ?? "rabbitmq";
string rabbitPassword = builder.Configuration.GetSection("RabbitMQ:Password").Value ?? "rabbitmq";

builder.Services.AddMassTransit(x =>
{
	x.UsingRabbitMq((context, cfg) =>
	{
		// By default, listens on port 5672
		// In Docker Compose, services need to reference each other by their service name, not localhost.
		cfg.Host(hostname, "/", h =>
		{
			h.Username(rabbitUsername);
			h.Password(rabbitPassword);
		});

		// Configure endpoints
		cfg.ConfigureEndpoints(context);
	});
});

var dependencyModule = new DependencyModule();
dependencyModule.RegisterDependencies(builder.Services);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    // Change the path to include our nginx prefix
    c.SwaggerEndpoint("/api/product/swagger/v1/swagger.json", "Product API V1");
    // Make sure we're not adding an additional swagger prefix
    c.RoutePrefix = "swagger";
});

app.UseCors("Policy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
