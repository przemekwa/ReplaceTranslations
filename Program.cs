using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var lines = File.ReadAllLines("translation_from_jeronimo.txt");
            var linesTrns = File.ReadAllLines("SelgrosPG_Translations.csv");
            
            foreach (var lineFromJeronimo  in lines)
            {
                Console.WriteLine(lineFromJeronimo);

                var result = false;

                var split = lineFromJeronimo.Split('\t', StringSplitOptions.RemoveEmptyEntries);

                if (split.Length != 3)
                {
                    Console.WriteLine($"Bad translation from translation_from_jeronimo {lineFromJeronimo}");
                    continue;
                }

                for (int i = 0; i < linesTrns.Length; i++)
                {
                    string[] splitOrig = linesTrns[i].Split('\t', StringSplitOptions.RemoveEmptyEntries);

                    if (splitOrig[0].Equals(split[0]))
                    {
                        var newTrans = new StringBuilder();

                        newTrans.Append(split[0]);
                        newTrans.Append('\t');
                        newTrans.Append(split[1]);
                        newTrans.Append('\t');
                        newTrans.Append(split[2]);
                        newTrans.Append('\t');
                        newTrans.Append(splitOrig[3]);
                        newTrans.Append('\t');
                        newTrans.Append(splitOrig[4]);
                        newTrans.Append('\t');
                        newTrans.Append(splitOrig[5]);

                        linesTrns[i] = newTrans.ToString();
                        result = true;
                        continue;

                    }
                }

                Console.WriteLine($"Replace: {result}");


            }

            File.Delete("SelgrosPG_Translations_NEW.csv");

            File.WriteAllLines("SelgrosPG_Translations_NEW.csv", linesTrns);

        }
    }
}
