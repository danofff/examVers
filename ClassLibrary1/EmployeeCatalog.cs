using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Model.Human
{
        public class EmployeeCatalog
        {
            public string pathToEmployeeCatalog { get; set; } = "employeeCatalog.xml";

            private string pathToLogData = "logData.txt";

            public bool CreateEmployee(Employee employee)
            {
                employee.saveEmployeeCard();
                List<Employee> employeeList = GetEmployees();
                employeeList.Add(employee);

                XmlSerializer formatter = new XmlSerializer(typeof(List<Employee>));
                try
                {
                    using (FileStream fs = new FileStream(pathToEmployeeCatalog, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, employeeList);
                    }
                    logData(employee.Name + "was created");
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    logData("unseccsessed employee creation");
                    return false;
                }
            }
            public List<Employee> GetEmployees()
            {
                List<Employee> employeeList = new List<Employee>();
                XmlSerializer formatter = new XmlSerializer(typeof(List<Employee>));
                FileInfo fi = new FileInfo(pathToEmployeeCatalog);
                if (fi.Exists)
                {
                    using (FileStream fs = new FileStream(pathToEmployeeCatalog, FileMode.OpenOrCreate))
                    {
                        employeeList = (List<Employee>)formatter.Deserialize(fs);
                    }
                }
                return employeeList == null ? new List<Employee>() : employeeList;
            }

            public void DeleteEmployee(string name)
            {
                Employee emplExist = FindByName(name);
                if (emplExist == null)
                {
                    logData("unsucsessful try employee delete");
                    return;
                }

                List<Employee> employeeList = GetEmployees();
                XmlSerializer formatter = new XmlSerializer(typeof(List<Employee>));
                FileInfo fi = new FileInfo(pathToEmployeeCatalog);
                if (fi.Exists)
                {
                    using (FileStream fs = new FileStream(pathToEmployeeCatalog, FileMode.OpenOrCreate))
                    {
                        employeeList = (List<Employee>)formatter.Deserialize(fs);
                    }

                    employeeList.Remove(emplExist);
                    logData(emplExist.Name + "was deleted");

                    using (FileStream fs= new FileStream(pathToEmployeeCatalog, FileMode.Truncate))
                    {
                    }
                    
                    try
                    {
                        using (FileStream fs = new FileStream(pathToEmployeeCatalog, FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, employeeList);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            public void EditEmployee(string name)
            {
                Employee employeExist = FindByName(name);

                if (employeExist == null)
                {
                    return;
                }

                Employee empl = new Employee();
                Console.WriteLine("Ведите имя сотрудника");             
                empl.Name=Console.ReadLine();
                Console.WriteLine("Ведите заработную плату сотрудника");
                double salary = 0;
                while (!Double.TryParse(Console.ReadLine(), out salary))
                {
                    Console.WriteLine("Вы ввели не число");
                }
                int p = 0;           
                Console.WriteLine("Выберете должность:");
                Console.WriteLine("1. manager\n2. accountant\n3.economist\n4system_administrator\n5. boss");

                while (true)
                {
                    while (!Int32.TryParse(Console.ReadLine(), out p))
                    {
                        Console.WriteLine("Вы ввели не число");
                    }
                    if (p == 1 || p == 2 || p == 3 || p == 4 || p == 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Нет такой должности");
                    }
                }
                Position.position posEnum = (Position.position)p;
                Position.Position position = new Position.Position(posEnum);
                empl.Position = position;

                DeleteEmployee(name);
                logData(empl.Name + "was edited");
                CreateEmployee(empl);
            }

            public Employee FindByName(string name)
            {
                List<Employee> employeeList = new List<Employee>();
                XmlSerializer formatter = new XmlSerializer(typeof(List<Employee>));
                FileInfo fi = new FileInfo(pathToEmployeeCatalog);
                if (fi.Exists)
                {
                    using (FileStream fs = new FileStream(pathToEmployeeCatalog, FileMode.OpenOrCreate))
                    {
                        employeeList = (List<Employee>)formatter.Deserialize(fs);
                    }

                    for (int i = 0; i < employeeList.Count; i++)
                    {
                        if (employeeList[i].Name == name)
                        {
                            return employeeList[i];
                        }
                    }
                        Console.WriteLine("Нет такого сотрудника");
                }                  
                return null;
            }

            public void PrintEmployees()
            {
                List<Employee> employeeList = GetEmployees();
                foreach (Employee item in employeeList)
                {
                    item.Print();
                }
                logData("Employee list was printed");
            }

            public void PrintStat()
            {
                List<Employee> employeeList = GetEmployees();
                if (employeeList != null && employeeList.Count != 0)
                {
                    double averSalary = 0;
                    double sum = 0;
                    foreach (Employee item in employeeList)
                    {
                        sum += item.Salary;
                    }
                    averSalary = sum / employeeList.Count;
                    Console.WriteLine($"Количество сотрудников: {employeeList.Count} Средняя заработная плата: {averSalary}");
                }
                else
                {
                    Console.WriteLine("В вашей компании нет сотрудников");
                }

                logData("Statistic was printed");
            }

            private void logData(string data)
            {
                FileInfo fi = new FileInfo(pathToLogData);
                if (!fi.Exists)
                {
                    fi.Create();              
                }

                using (StreamWriter sw = new StreamWriter(pathToLogData,true, System.Text.Encoding.Default))
                {
                    data = DateTime.Now +" - " + data;
                    sw.WriteLine(data);
                    sw.Close();
                }

            }
        
    }
}
