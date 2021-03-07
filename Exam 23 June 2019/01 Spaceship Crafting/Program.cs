namespace _01_Spaceship_Crafting
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            var liquids = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var physicalItems = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queueLiquids = new Queue<int>(liquids);
            var stackItems = new Stack<int>(physicalItems);

            var craft = new Dictionary<string, int>()
            {
                {"Aluminium",0 },
                {"Carbon fiber",0 },
                {"Glass", 0 },
                {"Lithium",0 }
            };

            while (queueLiquids.Any() && stackItems.Any())
            {
                var currentLiquid = queueLiquids.Dequeue();
                var currentItem = stackItems.Pop();

                var sum = currentLiquid + currentItem;

                if (sum == 25)
                {
                    craft["Glass"]++;
                }
                else if (sum == 50)
                {
                    craft["Aluminium"]++;
                }
                else if (sum == 75)
                {
                    craft["Lithium"]++;
                }
                else if (sum == 100)
                {
                    craft["Carbon fiber"]++;
                }
                else
                {
                    stackItems.Push(currentItem + 3);
                }

            }

            var checkCountMaterials = craft.Where(x => x.Value > 0).Count();

            if (checkCountMaterials == 4)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (queueLiquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", queueLiquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (stackItems.Count > 0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", stackItems)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            foreach (var item in craft)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");

            }
        }
    }
}
