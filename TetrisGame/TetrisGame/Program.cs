using System;
using System.Threading;

class Tetris
{
    static int width = 10;
    static int height = 20;
    static char[,] board = new char[height, width];
    static Random random = new Random();

    static void Main()
    {
        InitializeBoard();
        while (true)
        {
            DropTetromino();
            ClearFullLines();
            RenderBoard();
            Thread.Sleep(500);
        }
    }

    static void InitializeBoard()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                board[y, x] = ' ';
            }
        }
    }

    static void DropTetromino()
    {
        int col = random.Next(0, width - 1);
        for (int row = 0; row < height; row++)
        {
            if (row > 0)
                board[row - 1, col] = ' ';
            if (row == height - 1 || board[row + 1, col] != ' ')
            {
                board[row, col] = '#';
                break;
            }
            board[row, col] = '#';
            RenderBoard();
            Thread.Sleep(100);
        }
    }

    static void ClearFullLines()
    {
        for (int y = 0; y < height; y++)
        {
            bool isFullLine = true;
            for (int x = 0; x < width; x++)
            {
                if (board[y, x] == ' ')
                {
                    isFullLine = false;
                    break;
                }
            }
            if (isFullLine)
            {
                for (int row = y; row > 0; row--)
                {
                    for (int x = 0; x < width; x++)
                    {
                        board[row, x] = board[row - 1, x];
                    }
                }
                for (int x = 0; x < width; x++)
                {
                    board[0, x] = ' ';
                }
            }
        }
    }

    static void RenderBoard()
    {
        Console.Clear();
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(board[y, x]);
            }
            Console.WriteLine();
        }
    }
}
