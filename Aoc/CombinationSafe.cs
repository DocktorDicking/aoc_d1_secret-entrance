namespace Aoc;

public class CombinationSafe : ICombinationSafe
{
    private CombinationDial _dial;
    private readonly int _maxValue = 99;

    public CombinationSafe()
    {
        _dial = new CombinationDial(_maxValue);
    }
    
    public int TurnCombinationDial(Direction direction, int targetValue)
    {
        return _dial.TurnDialTo(direction, targetValue);
    }
}

public interface ICombinationSafe
{
    
}