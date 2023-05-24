using System;
using System.IO;

namespace CodeUtilityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bun venit in aplicatia utilitara pentru cod!");

            while (true)
            {
                Console.WriteLine("\nAlegeti una dintre urmatoarele optiuni:");
                Console.WriteLine("1. Generati un nou fisier C#");
                Console.WriteLine("2. Deschideti un fisier C# existent");
                Console.WriteLine("3. Iesiti din aplicatie");

                Console.Write("Optiune: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    CreateNewFile();
                }
                else if (input == "2")
                {
                    OpenExistingFile();
                }
                else if (input == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Optiune invalida. Va rugam sa introduceti un numar de optiune valid.");
                }
            }
        }

        static void CreateNewFile()
        {
            Console.Write("Introduceti numele fisierului (fara extensie): ");
            string fileName = Console.ReadLine();

            string filePath = $"{fileName}.cs";

            if (File.Exists(filePath))
            {
                Console.WriteLine($"Fisierul {fileName} exista deja.");
                return;
            }

            try
            {
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.WriteLine("using System;");
                    writer.WriteLine();
                    writer.WriteLine("namespace MyNamespace");
                    writer.WriteLine("{");
                    writer.WriteLine("\tclass MyClass");
                    writer.WriteLine("\t{");
                    writer.WriteLine("\t\tstatic void Main(string[] args)");
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\tConsole.WriteLine(\"Hello, world!\");");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine("\t}");
                    writer.WriteLine("}");
                }

                Console.WriteLine($"Fisierul {fileName} a fost creat cu succes.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A aparut o eroare la crearea fisierului: {ex.Message}");
            }
        }

        static void OpenExistingFile()
        {
            Console.Write("Introduceti calea fisierului: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Fisierul {filePath} nu exista.");
                return;
            }

            try
            {
                using (StreamReader reader = File.OpenText(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A aparut o eroare la deschiderea fisierului: {ex.Message}");
            }
        }
    }
}
