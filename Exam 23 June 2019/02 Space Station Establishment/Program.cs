namespace _02_Space_Station_Establishment
{
    using System;
    using System.Linq;
    class Program
    {
        private const int MIN_STAR_POWER_NEEDED = 50;

        private static char[][] galaxy;
        private static int playerRow;
        private static int playerCol;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            galaxy = new char[n][];

            int starEnergySum = 0;

            LoadMatrix(n);

            while (starEnergySum < MIN_STAR_POWER_NEEDED)
            {
                var command = Console.ReadLine();

                var nextIndexRow = 0;
                var nextIndexCol = 0;

                if (command == "up")
                {
                    if (playerRow - 1 >= 0)
                    {
                        nextIndexRow = playerRow - 1;
                        nextIndexCol = playerCol;

                        starEnergySum = Moves(n, starEnergySum, nextIndexRow, nextIndexCol);

                    }
                }
                else if (command == "down")
                {
                    if (playerRow + 1 < n)
                    {
                        nextIndexRow = playerRow + 1;
                        nextIndexCol = playerCol;

                        starEnergySum = Moves(n, starEnergySum, nextIndexRow, nextIndexCol);
                    }
                }
                else if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        nextIndexRow = playerRow;
                        nextIndexCol = playerCol - 1;

                        starEnergySum = Moves(n, starEnergySum, nextIndexRow, nextIndexCol);
                    }
                }
                else if (command == "right")
                {
                    if (playerCol + 1 < galaxy[playerRow].Length)
                    {
                        nextIndexRow = playerRow;
                        nextIndexCol = playerCol + 1;
                        starEnergySum = Moves(n, starEnergySum, nextIndexRow, nextIndexCol);
                    }
                }
                if (nextIndexRow == 0 && nextIndexCol == 0)
                {
                    galaxy[playerRow][playerCol] = '-';
                    break;
                }
            }
            PrintResult(starEnergySum);
        }

        private static void PrintResult(int starEnergySum)
        {
            if (starEnergySum < MIN_STAR_POWER_NEEDED)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            else
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {starEnergySum}");

            foreach (var item in galaxy)
            {
                foreach (var element in item)
                {
                    Console.Write(element);
                }
                Console.WriteLine();
                {

                }
            }
        }

        private static int Moves(int n, int starEnergySum, int nextIndexRow, int nextIndexCol)
        {
            if (char.IsDigit(galaxy[nextIndexRow][nextIndexCol]))
            {
                starEnergySum += galaxy[nextIndexRow][nextIndexCol] - 48;
                galaxy[playerRow][playerCol] = '-';
                playerRow = nextIndexRow;
                playerCol = nextIndexCol;
                galaxy[playerRow][playerCol] = 'S';
            }

            else if (galaxy[nextIndexRow][nextIndexCol] == '-')
            {
                galaxy[playerRow][playerCol] = '-';
                playerRow = nextIndexRow;
                playerCol = nextIndexCol;
                galaxy[playerRow][playerCol] = 'S';
            }

            else if (galaxy[nextIndexRow][nextIndexCol] == 'O')
            {
                galaxy[playerRow][playerCol] = '-';
                playerRow = nextIndexRow;
                playerCol = nextIndexCol;
                galaxy[playerRow][playerCol] = '-';

                bool isTrue = false;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < galaxy[row].Length; col++)
                    {
                        if (galaxy[row][col] == 'O')
                        {
                            galaxy[row][col] = 'S';
                            playerRow = row;
                            playerCol = col;
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

            return starEnergySum;
        }

        private static void LoadMatrix(int n)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();

                if (input.Contains('S'))
                {
                    for (int col = 0; col < input.Length; col++)
                    {
                        if (input[col] == 'S')
                        {
                            playerRow = row;
                            playerCol = col;
                            break;
                        }
                    }
                }
                galaxy[row] = input;
            }
        }
    }
}
