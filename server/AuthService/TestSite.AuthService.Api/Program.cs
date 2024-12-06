using Microsoft.EntityFrameworkCore;
using System.Text;
using TestSite.AuthService.Api;
using TestSite.AuthService.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TestSiteCoreContext>(opt =>
	opt
		.UseNpgsql(builder.Configuration.GetConnectionString("TestSiteCore"))
		.UseSnakeCaseNamingConvention());

builder.Services.AddCors(o => o.AddPolicy("Policy", builder =>
			{
				builder.AllowAnyOrigin()
				.AllowAnyHeader()
				.AllowAnyMethod();
			}));

var connString = builder.Configuration.GetConnectionString("TestSiteCore");

// RegisterServices
var registrar = new ServiceRegistrar();
registrar.RegisterServices(builder.Services);

var app = builder.Build();

var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
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

//// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// app.UseSwagger();
// app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("Policy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
