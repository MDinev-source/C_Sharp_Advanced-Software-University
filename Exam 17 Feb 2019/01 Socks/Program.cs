namespace _01_Socks
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            var leftSocks = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            var rightSocks = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            var stackLeftSocks = new Stack<int>(leftSocks);
            var queueRightSocks = new Queue<int>(rightSocks);


            var sets = new List<int>();

            while (stackLeftSocks.Any() && queueRightSocks.Any())
            {
                var currentLeftSock = stackLeftSocks.Peek();
                var currentRightSock = queueRightSocks.Peek();

                if (currentLeftSock > currentRightSock)
                {
                    int sum = currentLeftSock + currentRightSock;

                    sets.Add(sum);
                    stackLeftSocks.Pop();
                    queueRightSocks.Dequeue();
                }

                else if (currentRightSock > currentLeftSock)
                {
                    stackLeftSocks.Pop();
                }
                else if (currentLeftSock == currentRightSock)

                {
                    queueRightSocks.Dequeue();

                    int increment = stackLeftSocks.Pop() + 1;
                    stackLeftSocks.Push(increment);
                }
            }

            Console.WriteLine(sets.Max());
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
