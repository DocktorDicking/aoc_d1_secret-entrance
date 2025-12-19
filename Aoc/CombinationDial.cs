namespace Aoc;

public class CombinationDial : ICombinationDial
{
    public DialEventListner dialEventListner = new();
    private int MaxValue { get; set; }
    private readonly int _minValue = 0;
    private int _currentValue;
    
    public CombinationDial(int maxValue, int startValue)
    {
        MaxValue = maxValue;
        _currentValue = startValue;
    }

    public List<string> ReadEvents()
    {
        return dialEventListner.PrintEvents();
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
        dialEventListner.TrackEvent(direction, _currentValue, _minValue, MaxValue);
    }
}

public class DialEventListner
{
    private List<DialEvent> _eventsList = new();

    public void TrackEvent(Direction direction, int ticks, int startValue, int endValue)
    {
        _eventsList.Add(
            new DialEvent
            {
                Direction = direction, 
                Ticks = ticks, 
                StartValue = startValue, 
                EndValue = endValue
            });
    }

    public List<string> PrintEvents()
    {
        var lines = new List<string>(_eventsList.Count);

        foreach (var dialEvent in _eventsList)
        {
            lines.Add($"Direction: {dialEvent.Direction}, Target: {dialEvent.Ticks}, StartValue: {dialEvent.StartValue}, EndValue: {dialEvent.EndValue}");
        }

        return lines;
    }
}

internal class DialEvent
{
    public Direction Direction { get; set; }
    public int Ticks { get; set; }
    public int StartValue { get; set; }
    public int EndValue { get; set; }
    public int Turns { get; set; }
}