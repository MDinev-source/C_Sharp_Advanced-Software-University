namespace _01_Lootbox
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            var inputFirst = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> firstBox = new Queue<int>(inputFirst);

            var inputSecond = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> secondBox = new Stack<int>(inputSecond);

            var claimedItems = new List<int>();


            while (firstBox.Any() && secondBox.Any())
            {
                int sumCheck = firstBox.Peek() + secondBox.Peek();

                if (sumCheck % 2 == 0)
                {
                    claimedItems.Add(sumCheck);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (firstBox.Count > 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            else
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
