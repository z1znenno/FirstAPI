using Microsoft.EntityFrameworkCore;
using FirstAPI.Services;
using FirstAPI.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserDbService>();
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

app.UseHttpsRedirection();
app.MapControllers();
app.Run();