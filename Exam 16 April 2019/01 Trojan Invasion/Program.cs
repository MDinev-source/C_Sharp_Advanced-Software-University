namespace _01_Trojan_Invasion
{
    using System;

    using System.Linq;

    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfWaves = int.Parse(Console.ReadLine());

            var inputPlates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queuePlates = new Queue<int>(inputPlates);

            for (int i = 1; i <= numberOfWaves; i++)
            {
                var inputWaves = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var stackWaves = new Stack<int>(inputWaves);

                if (i % 3 == 0)
                {
                    var newPlate = int.Parse(Console.ReadLine());
                    queuePlates.Enqueue(newPlate);
                }

                while (stackWaves.Any() && queuePlates.Any())
                {

                    var currentPlate = queuePlates.Peek();
                    var currentWave = stackWaves.Peek();

                    if (currentWave > currentPlate)
                    {
                        stackWaves.Push(stackWaves.Pop() - queuePlates.Dequeue());
                    }
                    else if (currentPlate > currentWave)
                    {
                        queuePlates.Enqueue(queuePlates.Dequeue() - stackWaves.Pop());

                        for (int j = 0; j < queuePlates.Count - 1; j++)

                        {
                            queuePlates.Enqueue(queuePlates.Dequeue());
                        }
                    }
                    else
                    {
                        queuePlates.Dequeue();
                        stackWaves.Pop();
                    }
                }

                if (i == numberOfWaves)
                {
                    if (stackWaves.Count > 0)
                    {
                        Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                        Console.WriteLine($"Warriors left: {string.Join(" ", stackWaves)}");
                    }
                    else
                    {
                        Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                        Console.WriteLine($"Plates left: {string.Join(" ", queuePlates)}");
                    }
                }
            }
        }
    }
}
