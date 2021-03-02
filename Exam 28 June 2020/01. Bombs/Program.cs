namespace _01._Bombs
{
    using System;

    using System.Linq;

    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var bombEffects = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var bombCasings = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queueBombEffect = new Queue<int>(bombEffects);
            var stackBombCasings = new Stack<int>(bombCasings);

            var countOfBombs = new Dictionary<string, int>
            {
                { "Datura Bombs", 0},
                { "Cherry Bombs", 0},
                { "Smoke Decoy Bombs", 0},
                };

            bool isTrue = false;

            while (queueBombEffect.Any() && stackBombCasings.Any())
            {
                var currentBombEffect = queueBombEffect.Peek();
                var currentBombCasing = stackBombCasings.Peek();

                var sum = currentBombEffect + currentBombCasing;

                var isSumResultEnough = sum == 40 || sum == 60 || sum == 120;

                if (isSumResultEnough)
                {

                    if (sum == 40)
                    {

                        countOfBombs["Datura Bombs"]++;
                    }
                    else if (sum == 60)
                    {

                        countOfBombs["Cherry Bombs"]++;
                    }

                    else if (sum == 120)
                    {

                        countOfBombs["Smoke Decoy Bombs"]++;
                    }

                    queueBombEffect.Dequeue();
                    stackBombCasings.Pop();

                    if (countOfBombs["Datura Bombs"] >= 3
                        && countOfBombs["Cherry Bombs"] >= 3
                        && countOfBombs["Smoke Decoy Bombs"] >= 3)
                    {
                        isTrue = true;
                        break;
                    }
                }

                else
                {
                    stackBombCasings.Pop();
                    stackBombCasings.Push(currentBombCasing - 5);
                }
            }

            if (isTrue)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (queueBombEffect.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", queueBombEffect)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (stackBombCasings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", stackBombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var item in countOfBombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
