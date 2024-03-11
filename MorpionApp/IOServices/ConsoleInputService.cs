using System.ComponentModel;

namespace MorpionApp;

public class ConsoleInputService: IInputService
{
    public Position? ReadInput(Game game, string msg)
    {
        var (row, column) = (0, 0);
        bool moved = false;
        while (!moved)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape:
                    game.PushEvent(Event.Event.Quit);
                    break;
                case ConsoleKey.RightArrow:
           
                    if (column >= 2)
                    {
                        column = 0;
                    }
                    else
                    {
                        column = column + 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (column <= 0)
                    {
                        column = 2;
                    }
                    else
                    {
                        column = column - 1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (row <= 0)
                    {
                        row = 2;
                    }
                    else
                    {
                        row = row - 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (row >= 2)
                    {
                        row = 0;
                    }
                    else
                    {
                        row = row + 1;
                    }
                    break;
                case ConsoleKey.Enter:
                    moved = true; 
                    break;
            }
            game.PushEvent(Event.Event.Move, new Position(row, column));
            game.PushEvent(Event.Event.Redraw);
        }
        return new Position(row, column);
    }
}