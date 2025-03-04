using NLog;
using NLog.Web;
using BusinessLayer.Interface;
using BusinessLayer.Service;
using RepositoryLayer.Service;
using RepositoryLayer.Interface;

var logger = LogManager.Setup().LoadConfigurationFromFile("NLog.config").GetCurrentClassLogger();

try
{
    logger.Info("Application is starting...");

    var builder = WebApplication.CreateBuilder(args);

    // Configure NLog as the logging provider
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Add services to the container
    builder.Services.AddControllers();
    builder.Services.AddScoped<IGreetingBL, GreetingBL>();
   
    // Swagger Configuration
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Application stopped due to an unexpected error.");
    throw;
}
finally
{
    LogManager.Shutdown();
}
