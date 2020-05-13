using System;
using System.Globalization;
using System.IO;

namespace Section13_exercicioFixacao
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {                               
                Console.WriteLine("Digite o caminho do arquivo");
                string sourcePath = Console.ReadLine();
                string targetPath = Path.GetDirectoryName(sourcePath) + Path.DirectorySeparatorChar + "out";
                Directory.CreateDirectory(targetPath );
                targetPath += Path.DirectorySeparatorChar + "summary.csv";

                using StreamReader reader = File.OpenText(sourcePath);
                using StreamWriter writer = File.AppendText(targetPath);
                while (!reader.EndOfStream)
                {
                    string[] fileLine = reader.ReadLine().Split(',');
                    int itemQty = int.Parse(fileLine[2]);
                    double itemAmount = double.Parse(fileLine[1], CultureInfo.InvariantCulture);

                    writer.WriteLine(fileLine[0] + ", " + (itemAmount * itemQty).ToString("F2", CultureInfo.InvariantCulture));

                }
            }
            catch( IOException e)
            {                
                Console.WriteLine("An error has ocurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
