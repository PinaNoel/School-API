
using school_api.API.Middlewares;
using school_api.Core.Interfaces;
using school_api.Infrastructure.Context;
using school_api.Infrastructure.Repositories;
using school_api.Infrastructure.UnitOfWork;


using Common = school_api.Application.Common;
using User = school_api.Application.Users;
using Auth = school_api.Application.Auth;

using Microsoft.EntityFrameworkCore;



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
builder.Services.AddDbContext<SchoolDataBaseContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.LogTo(Console.WriteLine, LogLevel.Warning);
    }
);


// Services
builder.Services.AddScoped<Common.Interfaces.IPasswordHasherService, Common.Services.PasswordHasherService>();
builder.Services.AddScoped<Common.Interfaces.IJwtService, Common.Services.JwtService>();
builder.Services.AddScoped<User.Interfaces.IUserService, User.Services.UserService>();
builder.Services.AddScoped<Auth.Interfaces.IAuthService, Auth.Services.AuthService>();

// Repositories - UoW
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();




var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();
app.UseMiddleware<ErrorHandlerMiddleware>();


app.Run();