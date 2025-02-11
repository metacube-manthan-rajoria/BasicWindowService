using Serilog;
using BasicWindowService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

// Added Logger Configuration
Log.Logger = 
            new LoggerConfiguration().MinimumLevel.Debug()
            .WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + "logs/log - .txt", rollingInterval: RollingInterval.Day).CreateLogger();

// Added logger to services
builder.Logging.Services.AddSerilog();

// Adding application to Windows Services
builder.Services.AddWindowsService(options => {
    options.ServiceName = "WinServe by Gamedemons";
});

var host = builder.Build();
host.Run();
