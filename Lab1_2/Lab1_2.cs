using System;
using System.IO;

namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\OS_Karpus";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            Console.WriteLine("Введите строку для записи в файл:");
            string text = Console.ReadLine();

            using (FileStream fstream = new FileStream($"{path}\stringinFile", FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Строка записана в файл");
            }

            using (FileStream fstream = File.OpenRead($"{path}\stringinFile.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }
            Console.WriteLine("Удалить файл? y/n");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "y":
                    path = @"D:\OS_Karpus\stringinFile.txt";
                    FileInfo fileInf = new FileInfo(path);
                    if (fileInf.Exists)
                    {
                        fileInf.Delete();
                    }
                    ConsoleWriteLine("Файл удалён");
                    break;

                case "n":
                    ConsoleWriteLine("Выбрано значение не удалять");
                    break;

                default:
                    ConsoleWriteLine("Значение не выбрано");
                    break;
            }
            Console.ReadLine();
        }
    }
}
