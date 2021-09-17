using Management.Data.Context;
using Management.Data.Repositories;
using Management.Data.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Management.API", Version = "v1" });
});

builder.Services.AddScoped<IManagementContext, ManagementSettings>();
builder.Services.AddScoped<IPartRepository, PartRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Management.API v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
