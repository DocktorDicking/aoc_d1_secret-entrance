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
    
    public int TurnDialTo(Direction direction, int target)
    {
        //TODO: Update this to use value
        return direction switch
        {
            Direction.Left => TurnDial(Direction.Left),
            Direction.Right => TurnDial(Direction.Right),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
    
    //TODO: This needs to go over each value when doing -- or ++ until it reaches the new direction.
    private int TurnDial(Direction direction)
    {
        if (direction == Direction.Left)
        {
            if (_currentValue == 0)
            {
                return MaxValue;
            }

            return _currentValue--;
        }
        if (direction == Direction.Right)
        {
            if (_currentValue == MaxValue)
            {
                return _minValue;
            }
            
            return _currentValue++;
        }
        
        throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
    }
}