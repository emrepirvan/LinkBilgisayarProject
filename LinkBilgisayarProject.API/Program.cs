using LinkBilgisayarProject.Core.Repositories;
using LinkBilgisayarProject.Core.Services;
using LinkBilgisayarProject.Core.UnitOfWorks;
using LinkBilgisayarProject.Data;
using LinkBilgisayarProject.Data.Repositories;
using LinkBilgisayarProject.Data.UnitOfWorks;
using LinkBilgisayarProject.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;
using LinkBilgisayarProject.Service.Mapping;
using LinkBilgisayarProject.Service.Configurations;
using LinkBilgisayarProject.Core.Configuration;
using LinkBilgisayarProject.Core.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//----------------------------------------------------------------------------------------
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
//---------------------------------------------------------------------------------------
builder.Services.AddScoped<ICommercialActivityRepository, CommercialActivityRepository>();
builder.Services.AddScoped<ICommercialActivityService, CommercialActivityService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

//----------------------------------------------------------------
builder.Services.AddDbContext<LinkAppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(LinkAppDbContext)).GetName().Name);
    });
});

#region Authentication Build
////-------------------------------------------------------------------------------------------------------
builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOption"));
builder.Services.Configure<List<Client>>(builder.Configuration.GetSection("Clients"));
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddIdentity<UserApp, RoleApp>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
}).AddEntityFrameworkStores<LinkAppDbContext>();

var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOption>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opti =>
{
    opti.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience[0],
        IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),

        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true
    };
});

//---------------------------------------------------------------------------------------------- 
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
