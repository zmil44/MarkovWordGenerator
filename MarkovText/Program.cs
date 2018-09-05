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
