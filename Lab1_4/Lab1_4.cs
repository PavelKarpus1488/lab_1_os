using System;
using System.Io;
using System.Text.Json;
using System.Threding.Tasks;

namespace Lab1_4
{
    class Worker
    {
        public string Name { get; set; }
        public int ID { get; set; }

    }

    class Program
    {
        static async Task Main(string[] args)
        {
            using (FileStream fs = new FileStream("person.json", FileMode.OpenOrCreate))
            {
                Worker Tom = new Worker() { Name = "R6853", ID = 5060396 };
                await JsonSerializer.SerializeAsync<Worker>(fs, tom)
                Console.WriteLine("Данные сохранены в файл");
            }

            using (FileStream fs = new FileStream("person.json", FileMode.Open))
            {
                Worker RestoredPerson = await JsonSerializer.Deserialize<Worker>(fs);
                Console.WriteLine($"Name: {RestoredPerson.Name} Age: {RestoredPerson.ID}");
            }

        }
    }
}
