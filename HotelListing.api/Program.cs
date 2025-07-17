using AutoMapper;
using HotelListing.api.Contracts;
using HotelListing.api.data;
using HotelListing.api.Repositories;
using HotelListing.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.ConstrainedExecution;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  // builder services is our container 

/*builder.Services.AddTransient ==> every class that needs the dependancy has a new instance
builder.Services.AddScoped      ==> one instance for all classes per request (used most of time)
builder.Services.AddSingleton ==> one instance despite any number of requests 
*/

/*builder.Services.AddScoped<IProductService, ProductService>();   When someone asks for an IProductService, give them a ProductService
Once you register things in Program.cs, the framework injects them into constructors:

public class ProductController : ControllerBase {
    private readonly IProductService _productService;

    public ProductController(IProductService productService) {
        _productService = productService; // <-- Automatically injected!
    }
}
No need to new ProductService() — ASP.NET Core takes care of that automatically.*/


builder.Services.AddDbContext<HotelListingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Identity for security
builder.Services.AddIdentity<ApiUser, IdentityRole>()
    .AddEntityFrameworkStores<HotelListingDbContext>()
     .AddTokenProvider<DataProtectorTokenProvider<ApiUser>>("HotelListingApi");   // token

//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
//builder.Services.AddScoped<IHotelsRepository, HotelsRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // "Bearer"
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())            // if we are in development mode 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

// Configure middleware pipeline  // part of the request pipeline
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
