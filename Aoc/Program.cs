
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
        try
        {
            Console.WriteLine("Starting dial:");
            Console.WriteLine(_safe.TurnCombinationDial(Direction.Right, 100));
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exception thrown and caught: ");
            Console.WriteLine(e);
        }
    }
}