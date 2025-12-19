
using Aoc;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Register services
services.AddSingleton<CombinationSafe>();
services.AddTransient<App>();

using var provider = services.BuildServiceProvider();

provider.GetRequiredService<App>().Run(args);



public sealed class App
{
    private readonly CombinationSafe _safe;

    public App(CombinationSafe safe) => _safe = safe;

    public void Run(string[] args)
    {
        //TODO: I went sideways, we should not get to a target but the R15 means 15 times turn the dial right.
        
        try
        {
            Console.WriteLine("Starting combination safe");
            _safe
                .AddDialTurn(Direction.Left, 68)
                .AddDialTurn(Direction.Left, 30)
                .AddDialTurn(Direction.Right, 48)
                .AddDialTurn(Direction.Left, 5)
                .AddDialTurn(Direction.Right, 60)
                .AddDialTurn(Direction.Left, 55)
                .AddDialTurn(Direction.Left, 1)
                .AddDialTurn(Direction.Left, 99)
                .AddDialTurn(Direction.Right, 14)
                .AddDialTurn(Direction.Left, 82)
                .Run();

            var stats = _safe.GetStatistics();
            foreach (var stat in stats) Console.WriteLine(stat);
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exception thrown and caught: {0}", e);
        }
    }
}