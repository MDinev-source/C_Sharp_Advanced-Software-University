using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxCapacity = int.Parse(Console.ReadLine());

            var stackElements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var stackRegistration = new Stack<string>(stackElements);


            var queueReserveElement = new Queue<string>();

            var result = new List<string>();

            int sum = 0;

            while (stackRegistration.Any())
            {
                if (char.IsLetter(stackRegistration.Peek()[0]))
                {
                    queueReserveElement.Enqueue(stackRegistration.Pop());
                }
                else
                {
                    if (queueReserveElement.Count > 0)
                    {
                        sum += int.Parse(stackRegistration.Peek());

                        if (sum <= maxCapacity)
                        {
                            result.Add(stackRegistration.Pop());
                        }
                        else
                        {
                            Console.Write($"{queueReserveElement.Dequeue()} -> ");
                            Console.WriteLine(string.Join(", ", result));
                            sum = 0;
                            result.Clear();
                        }
                    }

                    else
                    {
                        while (char.IsDigit(stackRegistration.Peek()[0]))
                        {
                            stackRegistration.Pop();

                            if (stackRegistration.Count == 0)
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
