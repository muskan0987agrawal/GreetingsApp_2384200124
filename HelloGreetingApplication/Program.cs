using NLog;
using NLog.Web;
using BusinessLayer.Interface;
using BusinessLayer.Service;
using RepositoryLayer.Service;
using RepositoryLayer.Interface;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;


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
    builder.Services.AddScoped<IGreetingRL, GreetingRL>();

    //builder.Services.AddDbContext<GreetingDbContext>(options =>
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    var connectionString = builder.Configuration.GetConnectionString("sqlConnection");
    builder.Services.AddDbContext<GreetingDbContext>(options => options.UseSqlServer(connectionString));
   
    // Swagger Configuration
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    // Swagger Configuration with XML Comments
    builder.Services.AddSwaggerGen(c =>
    {
        var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    });

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
