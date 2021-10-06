using Acquisition.API.GrpcService;
using Acquisition.Infrastructure.Repositories;
using Discount.Grpc.Protos;
using System.Security.Policy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});

builder.Services.AddScoped<IAcquisitionRepository, AcquisitionRepository>();
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
    (g => g.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]));

builder.Services.AddScoped<DiscountGrpcService>();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Acquisition.API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Acquisition.API v1"));
}


app.UseAuthorization();

app.MapControllers();

app.Run();
