namespace P01.Lootbox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Queue<int> first = new Queue<int>();
            Stack<int> second = new Stack<int>();
            List<int> sums = new List<int>();
            int[] firstInput = Console
                .ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondInput = Console
                .ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            foreach (var number in firstInput)
            {
                first.Enqueue(number);
            }
            foreach (var number in secondInput)
            {
                second.Push(number);
            }

            while (first.Any() && second.Any())
            {
                int a = first.Peek();
                int b = second.Peek();
                int sum = a + b;
                if (sum % 2 == 0)
                {
                    sums.Add(sum);
                    first.Dequeue();
                    second.Pop();
                }
                else
                {
                    first.Enqueue(b);
                    second.Pop();
                }
            }
            if (!first.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (!second.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }
            int sumOfsums = sums.Sum();
            if (sumOfsums >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumOfsums}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumOfsums}");
            }
        }
    }
}
