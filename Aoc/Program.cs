
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
            Console.WriteLine("Starting dial:");
            _safe.TurnCombinationDial(Direction.Right, 15);
            _safe.TurnCombinationDial(Direction.Left, 12);
            _safe.TurnCombinationDial(Direction.Right, 5);

            var stats = _safe.GetStatistics();
            foreach (var stat in stats) Console.WriteLine(stat);
            
            //TODO: Introduce a Builder pattern so we can chain all the combinations turns we need.
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exception thrown and caught: {0}", e);
        }
    }
}