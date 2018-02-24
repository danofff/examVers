using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Human
{
    public  abstract class Person
    {
        public Person():this("noname")
        {

        }
        public Person (string name)
        {
            Name = name;
        }

        public Person(string Name, int Age)
        {

        }
        public string Name { get; set; }
        public int Age { get; set; }

        public bool IsMarried { get; set; }

        public virtual void Print()
        {
            string info = "Name: " + Name + "\n" + "Age: " + Age + "\n" + "Married " + (IsMarried ? "yes" : "no");
            Console.WriteLine(info);
        }
    }
}
