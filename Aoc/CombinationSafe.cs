namespace Aoc;

public class CombinationSafe : ICombinationSafe
{
    private readonly CombinationDial _dial;
    private readonly int _maxValue = 99;
    private readonly int _startValue = 50;

    public CombinationSafe()
    {
        _dial = new CombinationDial(_maxValue, _startValue);
    }
    
    public int TurnCombinationDial(Direction direction, int targetValue)
    {
        if (targetValue > _maxValue)
            // Fun fact, using string interpolation with the logger will create a new string every time. Structured logging is the way to make that more optimized.
            throw new ArgumentOutOfRangeException(nameof(targetValue), targetValue, $"Target value must be less than or equal to {_maxValue}.");
        
        return _dial.TurnDialTo(direction, targetValue);
    }

    public int GetStatistics()
    {
        return 0;
    }
}

public interface ICombinationSafe
{
    
}