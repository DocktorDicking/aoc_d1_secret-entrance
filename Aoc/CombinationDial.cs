namespace Aoc;

public class CombinationDial : ICombinationDial
{
    public int MaxValue { get; set; }
    private readonly int _minValue = 0;
    private int _currentValue;
    
    public CombinationDial(int maxValue)
    {
        MaxValue = maxValue;
        _currentValue = 0;
    }
    
    /**
     * Recursion is not the best way to solve this problem.
     * Apparently, each recursive call will be a new stack frame (function call + keeping track of the return address).
     * This is also considered riskier than iterative solutions.
     * But since this is for fun, recursion goes brrrr.
     */
    public int TurnDialTo(Direction direction, int target)
    {
        if (_currentValue == target)
        {
            return _currentValue;
        }
        
        TurnDial(direction);
        return TurnDialTo(direction, target);
    }
    
    private int TurnDial(Direction direction)
    {
        if (direction == Direction.Left)
        {
            if (_currentValue == 0)
            {
                return _currentValue = MaxValue;
            }

            return _currentValue--;
        }
        if (direction == Direction.Right)
        {
            if (_currentValue == MaxValue)
            {
                return _currentValue = _minValue;
            }
            
            return _currentValue++;
        }
        
        throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
    }
}