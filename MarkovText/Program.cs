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
            //the path three directories above teh executable directory in VS
            //from https://stackoverflow.com/a/14549805
            string wanted_path = Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(
                            Directory.GetCurrentDirectory())));
            string filePath = $"{wanted_path}\\words_alpha.txt";
            var lines = File.ReadAllLines(filePath);
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }
    }
}
