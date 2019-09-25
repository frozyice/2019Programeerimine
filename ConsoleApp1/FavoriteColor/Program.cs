using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Person;

namespace FavoriteColor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            //string[] lines = File.ReadAllLines(@"C:\Users\opilane\Documents");

            string[] lines = File.ReadAllLines("TextFile1.txt");

            foreach(var line in lines)
            {
                var names = line.Split(' ');
                Person person = new Person(names[0], names[1]);
                people.Add(person);
            }

            Console.WriteLine("Please enter Your last name: ");
            string lastName = Console.ReadLine();

            Person someone = people.FirstOrDefault(x => x.Lastname == lastName);
            Console.WriteLine($"Hi!, {someone.Firstname}! What is your fav color?");
            var answer = Console.ReadLine();

            Enum.TryParse(answer, true, out Color favoriteColor);
            someone.FavoriteColor = favoriteColor;

            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;

            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine($"{someone.Firstname} {someone.Lastname} Fav color: {someone.FavoriteColor}");
            }

            
        }
    }
}
