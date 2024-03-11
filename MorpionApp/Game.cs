namespace MorpionApp;

public abstract class Game
{
    protected int[,] _grid;
    protected int width, height;
    protected Player? _currentPlayer;
    protected Player[] _players;
    private int[] _playerCursors;
    protected IInputService _inputService;
    protected IOutputService _outputService;
    
    private Queue<(Event.Event @event,object? args)> _eventQueue;
    
    public void Play()
    {
        while (!IsFinished)
        {
            DoTurn();
            ProcessEvents();
            SwitchPlayer();
        }
    }
    public void Draw()
    {
       // draw the grid with borders and current player cursor on top
    }
    private void ProcessEvents()
    {
        while (_eventQueue.Count > 0)
        {
            var eventTuple = _eventQueue.Dequeue();
            var e = eventTuple.@event;
            var args = eventTuple.args;
            switch (e)
            {
                case Event.Event.Quit:
                    _outputService.Write("Quitting\n");
                    break;
                case Event.Event.Redraw:
                    Draw();
                    break;
                case Event.Event.Move:
                    // no need to emit errors here, the player will be asked to play again
                    if (args is Position position)
                    {
                        if (isValidMove(position))
                        {
                            var index = Array.IndexOf(_players, _currentPlayer);
                            _grid[position.Row, position.Column] = index;
                        }
                    }
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    public void PushEvent(Event.Event e)
    {
        _eventQueue.Enqueue((e,null));
    }
    public void PushEvent(Event.Event e, object args)
    {
        _eventQueue.Enqueue((e,args));
    }
    protected Game(int width, int height, Player[] players)
    {
        this.width = width;
        this.height = height;
        // initialize grid with 0
        _grid = new int[width, height];
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                _grid[i, j] = 0;
            }
        }
        _players = players;
        _playerCursors = new int[players.Length];
        _currentPlayer = null;
        this._inputService = new ConsoleInputService();
        this._outputService = new ConsoleOutputService();
        this._eventQueue = new Queue<(Event.Event, object?)>();
    }
    protected virtual void SwitchPlayer()
    {
        if (_currentPlayer == null)
        {
            _currentPlayer = _players[0];
        }
        else
        {
            int index = Array.IndexOf(_players, _currentPlayer);
            _currentPlayer = _players[(index + 1) % _players.Length];
        }
    }
    protected abstract void DoTurn();
    protected abstract bool IsFinished { get; set;  }
    protected bool isValidMove(Position position)
    {
        return _grid[position.Row, position.Column] == 0;
    }
}