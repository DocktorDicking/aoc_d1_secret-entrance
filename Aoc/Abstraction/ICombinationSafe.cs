namespace Aoc;

public interface ICombinationSafe
{
    CombinationSafe AddDialTurn(Direction direction, int ticks);
    List<string> GetStatistics();
    void Run();
}