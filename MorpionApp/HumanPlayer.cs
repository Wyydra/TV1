namespace MorpionApp;

public class HumanPlayer: Player
{
    public HumanPlayer(char symbol) : base(symbol)
    {
    }

    public override Position ReadInput(Game game, string msg)
    {
        Console.WriteLine(msg);
        game.Draw();
        // set cursor position on the center of the board
        var (row, col) = (0, 0);
        bool moved = false;
        while (!moved)
        {
            int r = 1 + col * (Game.CellWidth + 1);
            int c = 0 + row * (Game.CellHeight / 2);
            Console.SetCursorPosition(r, c);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.RightArrow:
                    if (col >= 2)
                    {
                        col = 0;
                    }
                    else
                    {
                        col = col + 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (col <= 0)
                    {
                        col = 2;
                    }
                    else
                    {
                        col = col - 1;
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
            game.Draw();
        }

        return new Position(row, col);
    }
}