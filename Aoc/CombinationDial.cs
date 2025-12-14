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
        
        var startValue = _currentValue;
        TurnDial(direction);
        dialEventListner.TrackEvent(direction, target, startValue, _currentValue);
        return TurnDialTo(direction, target);
    }

    public List<string> ReadEvents()
    {
        return dialEventListner.PrintEvents();
    }
    
    private void TurnDial(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left when _currentValue == 0:
                _currentValue = MaxValue;
                return;
            case Direction.Left:
                _currentValue--;
                return;
            case Direction.Right when _currentValue == MaxValue:
                _currentValue = _minValue;
                return;
            case Direction.Right:
                _currentValue++;
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
}

public class DialEventListner
{
    private List<DialEvent> _eventsList = new();

    public void TrackEvent(Direction direction, int target, int startValue, int endValue)
    {
        _eventsList.Add(
            new DialEvent
            {
                Direction = direction, 
                Target = target, 
                StartValue = startValue, 
                EndValue = endValue
            });
    }

    public List<string> PrintEvents()
    {
        var lines = new List<string>(_eventsList.Count);

        foreach (var dialEvent in _eventsList)
        {
            lines.Add($"Direction: {dialEvent.Direction}, Target: {dialEvent.Target}, StartValue: {dialEvent.StartValue}, EndValue: {dialEvent.EndValue}");
        }

        return lines;
    }

    public void PrintPassword()
    {
        //TODO: Filter list of events to only have events that passed the 0 at some point.
        throw new NotImplementedException("Not implemented yet.");
    }

}

internal class DialEvent
{
    public Direction Direction { get; set; }
    public int Target { get; set; }
    public int StartValue { get; set; }
    public int EndValue { get; set; }
    public int Turns { get; set; }
}