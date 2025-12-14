namespace Aoc;

public class CombinationSafe : ICombinationSafe
{
    private readonly CombinationDial _dial;
    private readonly int _maxValue = 99;

    public CombinationSafe()
    {
        _dial = new CombinationDial(_maxValue);
    }
    
    public int TurnCombinationDial(Direction direction, int targetValue)
    {
        if (targetValue > _maxValue)
            throw new ArgumentOutOfRangeException(nameof(targetValue), targetValue, $"Target value must be less than or equal to {_maxValue}.");
        
        return _dial.TurnDialTo(direction, targetValue);
    }
}

public interface ICombinationSafe
{
    
}