using LifeFitsHome.Contexts;
using LifeFitsHome.Repositories.Concrete;
using LifeFitsHome.Repositories.Interfaces;
using LifeFitsHome.Services.Concrete;
using LifeFitsHome.Services.Interfaces;
using LifeFitsHome.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DbContextBase>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenHelper, JwtHelper>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAddressRepository,AddressRepository>();
builder.Services.AddScoped<IAddressService,AddressService>();

builder.Services.AddScoped<IDistrictRepository,DistrictRepository>();
builder.Services.AddScoped<IDistrictService,DistrictService>();

builder.Services.AddScoped<ICityRepository,CityRepository>();
builder.Services.AddScoped<ICityService,CityService>();

builder.Services.AddScoped<IRegionRepository,RegionRepository>();
builder.Services.AddScoped<IRegionService,RegionService>();

builder.Services.AddScoped<IVaccineRepository,VaccineRepository>();
builder.Services.AddScoped<IVaccineService,VaccineService>();

builder.Services.AddScoped<IVaccineTypeRepository,VaccineTypeRepository>();
builder.Services.AddScoped<IVaccineTypeService,VaccineTypeService>();

builder.Services.AddScoped<IGenderService,GenderService>();
builder.Services.AddScoped<IGenderRepository,GenderRepository>();

builder.Services.AddScoped<IAreaRepository,AreaRepository>();
builder.Services.AddScoped<IAreaService,AreaService>();


var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
