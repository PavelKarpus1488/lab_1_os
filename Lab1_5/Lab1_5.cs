using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.IO;
class Program
{
	static void Main(string[] args)
    {
        XmlDocument xDoc = new XmlDocument();
        XDocument xdoc = new XDocument();
        Console.WriteLine("������� ������������� ����� ������?");
        int count = Convert.ToInt32(Console.ReadLine());
        XElement list = new XElement("list");
        for (int i = 1; i <= count; i++)
        {
            XElement chel = new XElement("chel");
            XAttribute username = new XAttribute("name", Console.ReadLine());
            XElement userage = new XElement("age", Covert.ToInt32(Console.ReadLine()));
            XElement usercompany = new XElement("company", Console.ReadLine());
            chel.Add(username);
            chel.Add(userage);
            chel.Add(usercompany);
            list.Add(chel)
        }

        xdoc.Add(list);
        xdoc.Save("users.xml");
        Console.WriteLine("��������� ������ ��� ���������� xml ����? y/n");
        switch (Console.ReadLine())
        {
            case "y":
                Console.WriteLine();
                xDoc.Load("users.xml");
                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count>0)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("name");
                        if (attr != null)
                            Console.WriteLine($"���: {attr.Value}");
                    }

                    foreach(XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "company")
                        {
                            Console.WriteLine($"��������: {childnode.InnerText}");
                        }

                        if (childnode.Name == "age")
                        {
                            Console.WriteLine($"�������: {childnode.InnerText}");
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("������� ��������� xml ����? y/n");
                switch (Console.ReadLine())
                {
                    case "y":
                        FileInfo xmlfilecheck = new FileInfo("users.xml");
                        if (xmlfilecheck.Exists)
                        {
                            xmlfilecheck.Delete();
                        }
                        break;
                    case "n":
                        break;
                    default:
                        Console.WriteLine("�� �� ������� ��������");
                        break;
                }
                Console.WriteLine();
                break;

            case "n":
                Console.WriteLine("������� ��������� xml ����? y/n");
                switch(Console.Readline())
                {
                    case "y":
                        FileInfo xmlfilecheck = new FileInfo("users.xml");
                        if (xmlfilecheck.Exists)
                        {
                            xmlfilecheck.Delete();
                        }
                        break;
                    case "n":
                        break;
                    default:
                        Console.WriteLine("�� �� ������� ��������");
                        break;
                }
                break;

            default:
                Console.WriteLine("�� �� ������� ��������");
                break;
        }

    }
}
