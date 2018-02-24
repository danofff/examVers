using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Position;
using System.Xml.Serialization;
using System.IO;

namespace Model.Human
{
    [Serializable]
    public class Employee:Person
    {
        private string pathEmployeeSave { get; set; }
        public Guid IdEmployee { get; set; }
        public Position.Position Position { get; set; }
        public double Salary { get; set; }

        public Employee():base()
        {
            Position = new Position.Position(position.manager);
            IdEmployee = Guid.NewGuid();
            pathEmployeeSave = Name.Replace(" ","")+ ".xml";
            Salary = Position.BaseSalary;
        }

        public Employee (Position.Position pos):base()
        {
            IdEmployee = Guid.NewGuid();
            Position = pos;
            pathEmployeeSave = Name.Replace(" ", "") + ".xml";
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Position: {0}\nSalary: {1}",Position.PositionName,Position.BaseSalary);
        }
    }
}
