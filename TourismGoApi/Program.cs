using Microsoft.EntityFrameworkCore;
using TourismGoDomain.Core.Interfaces;
using TourismGoDomain.Core.Services;
using TourismGoDomain.Infrastructure.Data;
using TourismGoDomain.Infrastructure.Repositories;
using TourismGoDomain.Infrastructure.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder.Services
    .AddDbContext<TourismGoContext>
    (options => options.UseSqlServer(cnx));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IActivityRepository, ActivityRepository>();
builder.Services.AddTransient<IBookingRepository, BookingRepository>();
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IJWTService, JWTService>();

builder.Services.AddSharedInfrastructure(_config);


builder.Services.AddControllers();
//CORS
builder.Services.AddCors(options => {

    options.AddDefaultPolicy(builder =>
    {
        builder//.WithOrigins("http:www.miempresa.com")
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
