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
            int r = 1 + col * (Grid.CellWidth + 1);
            int c = 0 + row * (Grid.CellHeight / 2);
            Console.SetCursorPosition(r, c);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.RightArrow:
                    if (col >= game.Width - 1)
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
                        col = game.Width - 1;
                    }
                    else
                    {
                        col = col - 1;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (row <= 0)
                    {
                        row = game.Height - 1;
                    }
                    else
                    {
                        row = row - 1;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (row >= game.Height - 1)
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