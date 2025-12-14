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
    
    public int GetNextValue(Direction direction)
    {
        return direction switch
        {
            Direction.Left => UpdateValue(Direction.Left),
            Direction.Right => UpdateValue(Direction.Right),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
    private int UpdateValue(Direction direction)
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