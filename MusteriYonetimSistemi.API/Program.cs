using Dapper.Application.Interfaces;
using Dapper.Infrastructure.DataAccess;
using Dapper.Infrastructure.Repository;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/MyLogs-.txt", rollingInterval:RollingInterval.Day)
    .CreateLogger();
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
