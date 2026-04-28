using Microsoft.EntityFrameworkCore;
using TestAPI.Interface;
using TestAPI.Model;
using TestAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// DB
var cc = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(cc);
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddScoped<IMembers, MembersRepository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// ❌ REMOVE THIS (important for Render)
// app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();
// ✅ ADD ROOT ROUTE
app.MapGet("/", () => "WebAPI is running successfully");
// ✅ IMPORTANT FOR RENDER PORT
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"http://0.0.0.0:{port}");
