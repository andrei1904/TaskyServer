namespace TaskyServer;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }

    // private static IWebHost CreateHostBuilder(string[] args)
    // {
    //     return WebHost.CreateDefaultBuilder(args)
    //         .UseStartup<Startup>()
    //         .Build();
    //     // .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    // }
}