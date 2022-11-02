using System;
using System.IO;
using System.Compression;

class Program
{
    static void Main(string[] args)
    {
        string[] namelist = { ".//archive", ".//text_dezip", "text.zip" };
        FileInfo check = new FileInfo(namelist[2]);
        if (check.Exists)
        {
            File.Delete(namelist[2]);
            try
            {
                Directory.Delete(namelist[0], true);
                Directory.Delete(namelist[0], true);
            }
            catch
            { }
        }
        else
        {
            DirectoryInfo dirinfo = new DirectoryInfo("archive");
            try
            {
                dirinfo.Create();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        Console.WriteLine("������� ������ ��� ������ � ����:");
        string text = Concole.Readline();
        DirectoryInfo dirinfo1 = new DirectoryInfo(namelist[0]);
        dirinfo1.Create();
        using (FileStream fstream = new FileStream($"{namelist[0]}\\note.txt", FileMode.OpenOrCreate))
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(text);
            fstream.Write(array, 0, array.Length);
            Console.WriteLine("����� ������� � ����");
        }
        Console.WriteLine();
        ZipFile.CreateFromDirectory(namelist[0], namelist[2]);
        Console.WriteLine($"����� {namelist[0]} ������������ � ���� {namelist[2]});
        Console.WriteLine();
        FileInfo dileinf = new FileInfo(namelist[2]);
        if (fileInf.Exists)
        {
            Console.WriteLine("��� �����: {0}", fileInf.Name);
            Console.WriteLine("����� ��������: {0}", fileInf.CreationTime);
            Console.WriteLine("��� �����: {0}", fileInf.Extension)
            Console.WriteLine("������: {0}", fileInf.Length)
        }
        Console.WriteLine("������� Enter, ����� ����������...")
        Console.ReadLine();
        DirectoryInfo dirinfo2 = new DirectoryInfo(namelist[1]);
        dirinfo2.Create();
        ZipFile.ExtractToDirectory(namelist[2], namelist[1]);
        Console.WriteLine($"���� {namelist[2]} ���������� � ����� {namelist[1]}");
        FileInfo fileinf2 = new FileInfo(".//text_dezip//note.txt");
        if (fileinf2.Exists)
        {
            Console.WriteLine("��� �����: {0}", fileInf2.Name);
            Console.WriteLine("����� ��������: {0}", fileInf2.CreationTime);
            Console.WriteLine("��� �����: {0}", fileInf2.Extension)
            Console.WriteLine("������: {0}", fileInf2.Length)
        }
        Console.WriteLine();
        Console.WriteLine("������� Enter, ����� ����������...");
        Console.ReadLine();
    }
}
