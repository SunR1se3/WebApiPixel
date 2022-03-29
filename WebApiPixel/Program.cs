using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApiPixel.AppServices.Services;
using WebApiPixel.DataAccess;
using WebApiPixel.Infrastructure.Repository;
using WebApiPixel.Mapper.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiPixel", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationConnection")));

builder.Services.AddScoped<DbContext>(s => s.GetRequiredService<BaseDbContext>());

//конфигурация автомаппера
builder.Services.AddAutoMapper(typeof(ApplicationMapperProfile));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddTransient<IEmployeeService, EmployeeService>();

builder.Services.AddTransient<IOrderHronologyService, OrderHronologyService>();

builder.Services.AddTransient<IEmployeeOrderService, EmployeeOrderService>();

builder.Services.AddTransient<IWareService, WareService>();

builder.Services.AddTransient<IOrderService, OrderService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "WebApiPixel v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
