using DapperASPNetCore.Context;
using DapperASPNetCore.Helpers;
using DapperASPNetCore.Interfaces;
using DapperASPNetCore.Repository;
using DapperASPNetCore.Services;
using System.Data;
using WebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.UseEndpoints(x => x.MapControllers());

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
