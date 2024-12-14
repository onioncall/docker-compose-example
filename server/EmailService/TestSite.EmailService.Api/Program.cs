using System.Reflection;
using System.Text;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TestSite.EmailService.Api;
using TestSite.EmailService.Api.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("Policy", builder =>
			{
				builder.AllowAnyOrigin()
				.AllowAnyHeader()
				.AllowAnyMethod();
			}));

var connString = builder.Configuration.GetConnectionString("TestSiteCore");

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
	x.AddConsumer<ProductInStockConsumer>();

	x.UsingRabbitMq((ctx, cfg) =>
	{
		// By default, listens on port 5672
		cfg.Host(hostname, "/", h =>
		{
			h.Username(rabbitUsername);
			h.Password(rabbitPassword);
		});

		// Configure endpoints
		cfg.ConfigureEndpoints(ctx);
	});
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();