using System;

namespace _02_Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new string[n, n];

            var firstPlayerRow = 0;
            var secondPlayerRow = 0;

            var firstPlayerCol = 0;
            var secondPlayerCol = 0;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col].ToString();
                    if (matrix[row, col] == "f")
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (matrix[row, col] == "s")
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }

                }
            }

            bool isLive = false;

            while (true)
            {
                var commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var commandFirstPlayer = commands[0];

                Moves(matrix, ref firstPlayerRow, ref firstPlayerCol, commandFirstPlayer);

                if (matrix[firstPlayerRow, firstPlayerCol] == "*")
                {
                    matrix[firstPlayerRow, firstPlayerCol] = "f";
                }
                else if (matrix[firstPlayerRow, firstPlayerCol] == "s")
                {
                    matrix[firstPlayerRow, firstPlayerCol] = "x";
                    isLive = true;
                }
                if (isLive)
                {
                    break;
                }

                var commandSecondPlayer = commands[1];

                Moves(matrix, ref secondPlayerRow, ref secondPlayerCol, commandSecondPlayer);

                if (matrix[secondPlayerRow, secondPlayerCol] == "*")
                {
                    matrix[secondPlayerRow, secondPlayerCol] = "s";
                }
                else if (matrix[secondPlayerRow, secondPlayerCol] == "f")
                {
                    matrix[secondPlayerRow, secondPlayerCol] = "x";
                    isLive = true;
                }
                if (isLive)
                {
                    break;
                }
            }

            MatrixPrint(matrix);
        }

        private static void MatrixPrint(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void Moves(string[,] matrix, ref int playerRow, ref int playerCol, string command)
        {
            if (command == "up")
            {
                playerRow --;

                if (playerRow < 0)
                {
                    playerRow = matrix.GetLength(0)-1;
                }
            }

            else if (command == "down")
            {
                playerRow ++;

                if (playerRow > matrix.GetLength(0) - 1)
                {
                    playerRow = 0;
                }
            }

            else if (command == "left")
            {
                playerCol --;
                if (playerCol < 0)
                {
                    playerCol = matrix.GetLength(1)-1;
                }
            }

            else if (command == "right")
            {
                playerCol ++;
                if (playerCol > matrix.GetLength(1) - 1)
                {
                    playerCol = 0;
                }
            }
        }
    }
}