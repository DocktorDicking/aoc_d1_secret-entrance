namespace Aoc;

public class CombinationSafe : ICombinationSafe
{
    private readonly CombinationDial _dial;
    private readonly int _maxValue = 99;
    private readonly int _startValue = 50;
    private readonly List<(Direction Direction, int Ticks)> _turns;

    public CombinationSafe()
    {
        _dial = new CombinationDial(_maxValue, _startValue);
        _turns = [];
    }
    
    public CombinationSafe AddDialTurn(Direction direction, int ticks)
    {
        _turns.Add((direction, ticks));
        return this;
    }

    public void Run()
    {
        _turns.ForEach(turn => _dial.TurnDial(turn.Direction, turn.Ticks));
    }

    public List<string> GetStatistics()
    { 
        return _dial.ReadEvents();
    }
}