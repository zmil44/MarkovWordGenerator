using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovText
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = FilePath();
            var lines = File.ReadAllLines(filePath);
            var model = new MarkovModel();
            model.AddWords(lines);

            string input;

            double real = 0;
            double total = 0;

            do
            {
                string word = model.GenerateWord(3, 10);
                bool realWord = lines.Contains(word);

                Console.WriteLine(word + (realWord ? " (real)" : ""));

                input = Console.ReadLine();

                total++;
                real += realWord ? 1 : 0;
            } while (input == "");

            Console.WriteLine($"Percentage real: {real / total}");
        }
        static string FilePath()
        {
            //the path three directories above teh executable directory in VS
            //from https://stackoverflow.com/a/14549805
            string wanted_path = Path.GetDirectoryName(
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Directory.GetCurrentDirectory())));
            return $"{wanted_path}\\words_alpha.txt";
        }
    }
}
