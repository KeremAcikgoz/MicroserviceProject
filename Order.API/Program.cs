using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Order.API.Clients;
using OrderAPI.Models.DbOperations;
using System.Buffers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddScoped<IOrderService, OrderService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddControllers().AddNewtonsoftJson();
//builder.Services.AddControllers()
//  .AddNewtonsoftJson(options =>
//      options.SerializerSettings.ReferenceLoopHandling =
//        Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrderDbContext>(options => options.UseInMemoryDatabase("OrderDB"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IOrderDbContext>(provider => provider.GetRequiredService<OrderDbContext>());
builder.Services.AddHttpClient<CustomerClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7001");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scoper = app.Services.CreateScope())
{
    var vertices = scoper.ServiceProvider;
    OrderDataGenerator.Initialize(vertices);
}


app.Run();
