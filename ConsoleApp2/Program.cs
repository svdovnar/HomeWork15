using System;
using System.IO;
using System.IO.Compression;

namespace ConsoleApp2
{
    class Program
    {
        static void Search(string directory, string fileName)
        {
            try
            {
                foreach (var f in Directory.GetFiles(directory, fileName))
                {
                    var archive = Path.Combine(directory, Path.GetFileNameWithoutExtension(f) + ".zip");
                    using (ZipArchive zip = ZipFile.Open(archive, ZipArchiveMode.Create))
                    {
                        zip.CreateEntryFromFile(f, fileName);
                    }
                    Console.WriteLine("Все ок. Путь к новому архиву:\n" + archive);
                }

                foreach (var d in Directory.GetDirectories(directory))
                {
                    Search(d, fileName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите название пути");
            var root = Console.ReadLine();

            Console.WriteLine("Введите название файла с расширением:");
            var file = Console.ReadLine();

            Search(root, file);
                                 
            Console.ReadLine();
        }
    }
}
