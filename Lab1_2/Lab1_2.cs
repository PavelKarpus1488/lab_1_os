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
            Console.WriteLine("������� ������ ��� ������ � ����:");
            string text = Console.ReadLine();

            using (FileStream fstream = new FileStream($"{path}\stringinFile", FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("������ �������� � ����");
            }

            using (FileStream fstream = File.OpenRead($"{path}\stringinFile.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"����� �� �����: {textFromFile}");
            }
            Console.WriteLine("������� ����? y/n");
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
                    ConsoleWriteLine("���� �����");
                    break;

                case "n":
                    ConsoleWriteLine("������� �������� �� �������");
                    break;

                default:
                    ConsoleWriteLine("�������� �� �������");
                    break;
            }
            Console.ReadLine();
        }
    }
}
