using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RulesEngine;

namespace ConsoleApplication1
{
    public class Person
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.For<Person>()
                    .Setup(p => p.DateOfBirth)
                        .MustBeLessThan(DateTime.Now)
                    .Setup(p => p.Name)
                        .MustNotBeNull()
                        .MustMatchRegex("^[a-zA-z]+$")
                    .Setup(p => p.Phone)
                        .MustNotBeNull()
                        .MustMatchRegex("^[0-9]+$");

            Person person = new Person();
            person.Name = "Bill";
            person.Phone = "1234214";
            person.DateOfBirth = new DateTime(1999, 10, 2);

            bool isValid = engine.Validate(person);
            Console.WriteLine(isValid);
            Console.ReadLine();
        }
    }
}
