using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Human;
using Position;

namespace examVers
{
    class Program
    {
        static void Main(string[] args)
        {
            Position.Position p1 = new Position.Position(Position.position.manager, 100000);
            Position.Position p2 = new Position.Position(Position.position.economist, 150000);
            Position.Position p3 = new Position.Position(Position.position.accountant, 150000);
            Position.Position p4 = new Position.Position(Position.position.system_administrator, 180000);
            Position.Position p5 = new Position.Position(Position.position.boss, 300000);

            Position.PositionCatalog posCatalog = new PositionCatalog();
            posCatalog.CreatePosition(p1);
            posCatalog.CreatePosition(p2);
            posCatalog.CreatePosition(p3);
            posCatalog.CreatePosition(p4);
            posCatalog.CreatePosition(p5);

            Employee empl1 = new Employee(p1);
            empl1.Name = "John Doe";
            Employee empl2 = new Employee(p2);
            empl2.Name = "John Man";
            Employee empl3 = new Employee(p3);
            empl3.Name = "John Glu";
            Employee empl4 = new Employee(p4);
            empl4.Name = "John Sam";
            Employee empl5 = new Employee(p5);
            empl5.Name = "John Ans";

            EmployeeCatalog emplCat = new EmployeeCatalog();

            emplCat.CreateEmployee(empl1);
            emplCat.CreateEmployee(empl2);
            emplCat.CreateEmployee(empl3);
            emplCat.CreateEmployee(empl4);
            emplCat.CreateEmployee(empl5);

            emplCat.DeleteEmployee("John Man");


        }
    }
}
