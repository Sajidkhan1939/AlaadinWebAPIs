using AlaadinWebAPIs.Models;
using AlaadinWebAPIs.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Get connect with connection string from appsettings.json
builder.Services.AddDbContext<Aladin_prp_dbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Aladin_prp_db")));
var _Jwtsettings = builder.Configuration.GetSection("Jwtsettings");
builder.Services.Configure<Jwtsettings>(_Jwtsettings);
// Ad Authentication
var _authkey = builder.Configuration.GetValue<string>("Jwtsettings:securitykey");
builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters() {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authkey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddTransient<IRole,RoleRepo>();
// Configure Identity
/*builder.Services.AddIdentity<AuthUser, IdentityRole>()
    .AddEntityFrameworkStores<Aladin_prp_dbContext>();*/
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(Options => Options.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
