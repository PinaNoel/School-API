
using school_api.API.Middlewares;
using school_api.Core.Interfaces;
using school_api.Infrastructure.Context;
using school_api.Infrastructure.Repositories;
using school_api.Infrastructure.UnitOfWork;


using Common = school_api.Application.Common;
using User = school_api.Application.Users;
using Auth = school_api.Application.Auth;

using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(); 
builder.Services.AddHttpContextAccessor();

// Logger config
builder.Logging.AddConsole();


//  _____ Dependency injection

// SQL Server
builder.Services.AddDbContext<SchoolDataBaseContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        options.LogTo(Console.WriteLine, LogLevel.Warning);
    }
);

builder.Services.AddScoped<Common.Interfaces.ICurrentUserService, CurrentUserService>();

// Services
builder.Services.AddScoped<Common.Interfaces.IPasswordHasherService, Common.Services.PasswordHasherService>();
builder.Services.AddScoped<Common.Interfaces.IJwtService, Common.Services.JwtService>();
builder.Services.AddScoped<User.Interfaces.IUserService, User.Services.UserService>();
builder.Services.AddScoped<Auth.Interfaces.IAuthService, Auth.Services.AuthService>();

// Repositories - UoW
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = false;

        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!))
        };

        options.Events = new CustomJwtEvents();
    }
);
builder.Services.AddAuthorization();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.Run();