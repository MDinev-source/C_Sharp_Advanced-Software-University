namespace _02_Re_Volt
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int sizeN = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            var matrix = new char[sizeN, sizeN];

            var rowCheck = 0;
            var colCheck = 0;

            bool isWon = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        rowCheck = row;
                        colCheck = col;
                    }
                }
            }
            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();

                matrix[rowCheck, colCheck] = '-';

                if (command == "up")
                {
                    if (rowCheck - 1 >= 0)
                    {
                        rowCheck--;
                    }
                    else
                    {
                        rowCheck = matrix.GetLength(0) - 1;
                    }

                    while (matrix[rowCheck, colCheck] != '-' && matrix[rowCheck, colCheck] != 'F')
                    {
                        if (matrix[rowCheck, colCheck] == 'T')
                        {
                            rowCheck++;
                        }
                        else if (matrix[rowCheck, colCheck] == 'B')
                        {
                            rowCheck--;
                        }

                        if (rowCheck < 0)
                        {
                            rowCheck = matrix.GetLength(0) - 1;
                        }

                    }
                    if (matrix[rowCheck, colCheck] == 'F')
                    {
                        isWon = true;
                        break;
                    }
                    matrix[rowCheck, colCheck] = 'f';

                }

                else if (command == "down")
                {
                    if (rowCheck + 1 < matrix.GetLength(0))
                    {
                        rowCheck++;
                    }
                    else
                    {
                        rowCheck = 0;
                    }
                    while (matrix[rowCheck, colCheck] != '-' && matrix[rowCheck, colCheck] != 'F')
                    {
                        if (matrix[rowCheck, colCheck] == 'T')
                        {
                            rowCheck--;
                        }
                        else if (matrix[rowCheck, colCheck] == 'B')
                        {
                            rowCheck++;
                        }

                        if (rowCheck == matrix.GetLength(0))
                        {
                            rowCheck = 0;
                        }

                    }

                    if (matrix[rowCheck, colCheck] == 'F')
                    {
                        isWon = true;
                        break;
                    }
                    matrix[rowCheck, colCheck] = 'f';

                }

                else if (command == "left")
                {
                    if (colCheck - 1 >= 0)
                    {
                        colCheck--;
                    }
                    else
                    {
                        colCheck = matrix.GetLength(1) - 1;
                    }

                    while (matrix[rowCheck, colCheck] != '-' && matrix[rowCheck, colCheck] != 'F')
                    {
                        if (matrix[rowCheck, colCheck] == 'T')
                        {
                            colCheck++;
                        }
                        else if (matrix[rowCheck, colCheck] == 'B')
                        {
                            colCheck--;
                        }
                        if (colCheck < 0)
                        {
                            colCheck = matrix.GetLength(1) - 1;
                        }

                    }
                    if (matrix[rowCheck, colCheck] == 'F')
                    {
                        isWon = true;
                        break;
                    }
                    matrix[rowCheck, colCheck] = 'f';

                }

                else if (command == "right")
                {
                    if (colCheck + 1 < matrix.GetLength(1))
                    {
                        colCheck++;
                    }
                    else
                    {
                        colCheck = 0;
                    }

                    while (matrix[rowCheck, colCheck] != '-' && matrix[rowCheck, colCheck] != 'F')
                    {
                        if (matrix[rowCheck, colCheck] == 'T')
                        {
                            colCheck--;
                        }
                        else if (matrix[rowCheck, colCheck] == 'B')
                        {
                            colCheck++;
                        }

                        if (colCheck == matrix.GetLength(1))
                        {
                            colCheck = 0;
                        }

                    }
                    if (matrix[rowCheck, colCheck] == 'F')
                    {
                        isWon = true;
                        break;
                    }
                    matrix[rowCheck, colCheck] = 'f';
                }

            }
            if (isWon)
            {
                matrix[rowCheck, colCheck] = 'f';
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            MatrixPrint(matrix);
        }
        static void MatrixPrint(char[,] matrix)
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
    }
}