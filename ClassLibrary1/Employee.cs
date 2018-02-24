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
        private string pathEmployeeSave { get;}
        public Guid IdEmployee { get; set; }
        public Position.Position Position { get; set; }
        public double Salary { get; set; }

        public Employee():base()
        {
            Position = new Position.Position(position.manager);
            IdEmployee = Guid.NewGuid();
            pathEmployeeSave = IdEmployee.ToString() + ".xml";
            Salary = Position.BaseSalary;
        }

        public Employee (Position.Position pos):base()
        {
            IdEmployee = Guid.NewGuid();
            Position = pos;
            pathEmployeeSave = IdEmployee.ToString() + ".xml";
        }


        public void saveEmployeeCard()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Employee));
            try
            {
                using (FileStream fs = new FileStream(pathEmployeeSave, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, this);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void deleteEmployeeCard()
        {
            FileInfo fi = new FileInfo(pathEmployeeSave);
            if (fi.Exists)
            {
                fi.Delete();
            }
            else
            {
                Console.WriteLine($"Нет файла {this.Name} сотрудника");
            }
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Position: {0}\nSalary: {1}",Position.PositionName,Position.BaseSalary);
        }
    }
}
