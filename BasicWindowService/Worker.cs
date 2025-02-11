using System.Diagnostics;

namespace BasicWindowService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly string fileUrl = AppDomain.CurrentDomain.BaseDirectory + "File.txt";

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                try
                {
                    using (EventLog eventLog = new EventLog("Application"))
                    {
                        eventLog.Source = "WinServe by Gamedemons";

                        if (File.Exists(fileUrl))
                        {
                            string fileContents = File.ReadAllText(fileUrl);
                            File.Delete(fileUrl);

                            eventLog.WriteEntry(fileContents, EventLogEntryType.SuccessAudit, 101, 1);
                        }
                        else
                        {
                            eventLog.WriteEntry("File not found", EventLogEntryType.FailureAudit, 101, 1);
                        }
                    }
                }
                catch (PlatformNotSupportedException e)
                {
                    Console.WriteLine();
                }
            }
            await Task.Delay(3000, stoppingToken);
        }
    }
}
