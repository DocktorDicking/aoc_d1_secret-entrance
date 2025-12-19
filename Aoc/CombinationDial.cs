namespace Aoc;

public class CombinationDial : ICombinationDial
{
    public DialEventListner dialEventListner = new();
    private int MaxValue { get; set; }
    private readonly int _minValue = 0;
    private int _currentValue;
    private readonly int _startValue;

    public CombinationDial(int maxValue, int startValue)
    {
        MaxValue = maxValue;
        _currentValue = startValue;
        _startValue = startValue;
    }

    public List<string> ReadEvents()
    {
        return dialEventListner.PrintEvents(_startValue);
    }
    
    public void TurnDial(Direction direction, int ticks)
    {
        for (int i = 0; i < ticks; i++)
        {
            switch (direction)
            {
                case Direction.Left when _currentValue == 0:
                    _currentValue = MaxValue;
                    break;
                case Direction.Left:
                    _currentValue--;
                    break;
                case Direction.Right when _currentValue == MaxValue:
                    _currentValue = _minValue;
                    break;
                case Direction.Right:
                    _currentValue++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
        dialEventListner.TrackEvent(direction, ticks, _currentValue);
    }
}

public class DialEventListner
{
    private readonly List<DialEvent> _eventsList= [];

    public void TrackEvent(Direction direction, int ticks, int value)
    {
        _eventsList.Add(
            new DialEvent
            {
                Direction = direction, 
                Ticks = ticks, 
                Value = value
            });
    }

    public List<string> PrintEvents(int startValue)
    {
        var lines = new List<string>(_eventsList.Count)
        {
            $"The Dial starts by pointing at {startValue}."
        };

        foreach (var dialEvent in _eventsList)
        {
            lines.Add($"The Dial is rotated {dialEvent.Direction} {dialEvent.Ticks} to point at: {dialEvent.Value}.");
        }
        
        lines.Add(PrintPassword());
        return lines;
    }

    private string PrintPassword()
    {
        var amount = _eventsList.FindAll(e => e.Value == 0).Count;
        return $"The password is: {amount}";
    }
}

internal class DialEvent
{
    public Direction Direction { get; set; }
    public int Ticks { get; set; }
    public int Value { get; set; }
}