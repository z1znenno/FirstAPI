using Microsoft.EntityFrameworkCore;
using FirstAPI.Services;
using FirstAPI.Data;
using FirstAPI.Middleware;
using FirstAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserDbService>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddDbContext<AppDbContext>
(
    option => 
    option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();