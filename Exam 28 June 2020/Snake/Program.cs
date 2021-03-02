namespace Snake
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());

            var territory = new char[n, n];

            var snakeRow = 0;
            var snakeCol = 0;
            var foodCount = 0;

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    territory[row, col] = input[col];

                    if (territory[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            while (foodCount < 10)
            {
                var command = Console.ReadLine();

                territory[snakeRow, snakeCol] = '.';

                if (command == "up")
                {
                    if (IsValid(territory, snakeRow - 1, snakeCol))
                    {
                        snakeRow--;

                        Moves(n, territory, ref snakeRow, ref snakeCol, ref foodCount);
                    }
                    else
                    {
                        break;
                    }
                }

                else if (command == "down")
                {
                    if (IsValid(territory, snakeRow + 1, snakeCol))
                    {
                        snakeRow++;
                        Moves(n, territory, ref snakeRow, ref snakeCol, ref foodCount);
                    }
                    else
                    {
                        break;
                    }
                }

                else if (command == "left")
                {
                    if (IsValid(territory, snakeRow, snakeCol - 1))
                    {
                        snakeCol--;
                        Moves(n, territory, ref snakeRow, ref snakeCol, ref foodCount);
                    }
                    else
                    {
                        break;
                    }
                }

                else if (command == "right")
                {
                    if (IsValid(territory, snakeRow, snakeCol + 1))
                    {
                        snakeCol++;
                        Moves(n, territory, ref snakeRow, ref snakeCol, ref foodCount);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (foodCount < 10)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodCount}");

            for (int row = 0; row < n; row++)
            {

                for (int col = 0; col < n; col++)
                {
                    Console.Write(territory[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void Moves(int n, char[,] territory, ref int snakeRow, ref int snakeCol, ref int foodCount)
        {
            if (territory[snakeRow, snakeCol] == '*')
            {
                foodCount++;
                territory[snakeRow, snakeCol] = 'S';
            }

            else if (territory[snakeRow, snakeCol] == 'B')
            {
                territory[snakeRow, snakeCol] = '.';

                bool isTrue = false;
                for (int row = 0; row < n; row++)
                {

                    for (int col = 0; col < n; col++)
                    {
                        if (territory[row, col] == 'B')
                        {
                            territory[row, col] = 'S';
                            snakeRow = row;
                            snakeCol = col;
                            isTrue = true;
                            break;
                        }
                    }
                    if (isTrue)
                    {
                        break;
                    }
                }
            }
        }

        private static bool IsValid(char[,] matrix, int playerRow, int playerCol)
        {
            if ((playerRow >= 0 && playerRow < matrix.GetLength(0)) && (playerCol >= 0 && playerCol < matrix.GetLength(1)))
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}
