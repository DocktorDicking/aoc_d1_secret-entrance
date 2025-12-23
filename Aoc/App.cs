namespace Aoc;

public sealed class App
{
    private readonly ICombinationSafe _safe;

    public App(ICombinationSafe safe) => _safe = safe;

    public void Run(string[] args)
    {
        try
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "input.txt");
            Console.WriteLine($"Reading file: {filePath}");
            _safe.AddDialTurnFromFile(filePath).Run();

            var stats = _safe.GetStatistics();
            foreach (string stat in stats) Console.WriteLine(stat);
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exception thrown and caught: {0}", e);
        }
    }
}