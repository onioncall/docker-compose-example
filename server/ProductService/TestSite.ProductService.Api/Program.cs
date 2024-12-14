using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestSite.MemberService.Persistence.Contexts;
using TestSite.ProductService.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

// RegisterServices
var registrar = new DependencyRegistrar();
registrar.RegisterDependencies(builder.Services);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("Policy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();