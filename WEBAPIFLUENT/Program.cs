using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<PDFContext>(
//    options =>
//    {
//        options.UseMySQL(builder.Configuration.GetSection("ConnectionStrings")["Default"]);
//    });

builder.Services.AddScoped<PDFContext>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IVarientRepository, VarientRepository>();
builder.Services.AddScoped<IBareBoardRepository, BareBoardRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAssembledBoardRepository, AssembledBoardRepository>();
builder.Services.AddScoped<IPowerUpRepository, PowerUpRepository>();
builder.Services.AddScoped<IHeadingRepository, HeadingRepository>();
builder.Services.AddScoped<ISubHeadingRepository,SubHeadingRepository>();
builder.Services.AddScoped<ISubHeadingImagesRepository, SubHeadingImagesRepository>();
builder.Services.AddScoped<IXLSheetRepository, XLSheetRepository>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(cookie =>
    {
        cookie.LoginPath = "/api/User/Login";
        cookie.AccessDeniedPath = "/api/User/AccessDenied";
        cookie.LogoutPath = "/api/User/Logout";
        cookie.ExpireTimeSpan = TimeSpan.FromMinutes(120);
        
    });
var app = builder.Build();
//Migrate the database on application startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PDFContext>();
    try
    {
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        // Handle any migration error here
        Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
    }
}
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
