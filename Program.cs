using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SF.Module21.Task2
{
    class Program
    {
        static void Main()
        {
            string text = File.ReadAllText("/Users/pdn/Desktop/Text.txt");
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            var words = noPunctuationText.Split(" ");

            var statistic = new Dictionary<string, int>();

            foreach (string word in words)
                if (statistic.ContainsKey(word))
                    statistic[word]++;
                else
                    statistic.Add(word, 1);

            int count = statistic.Count >= 10 ? 10 : statistic.Count;
            var orderedStatistic = statistic.OrderByDescending(w => w.Value).ToArray();

            for (int i = 0; i < count; i++)
                Console.WriteLine($"{orderedStatistic[i].Key} - {orderedStatistic[i].Value}");

            Console.ReadKey();
        }
    }
}
