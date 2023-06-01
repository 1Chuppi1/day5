using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace day5
{
    public class EmployeesBook
    {
        private List<Employees> employee = new List<Employees>(10)
            {
                new Employees("",1,18800,1),
                new Employees("",1,14737,2),
                new Employees("",2,28800,3),
                new Employees("",2,24737,4),
                new Employees("",3,38800,5),
                new Employees("",3,34737,6),
                new Employees("",4,48800,7),
                new Employees("",4,44737,8),
                

            };
        List<Employees> deletedemployee = new List<Employees>()
        {

        };

        public void Employeesbook()
        {
            double sumsalary = 0;
            double avgsalary = 0;
            double avgsalary2 = 0;
            int count = 0;
            int countforavg = 0;
            while (true)
            {
                Console.WriteLine("выберите раздел : \n 1 - задание на 30.03 \n 2 - задание на 03.04 \n 3 - задание на 05.04");
                int choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("выберите задание: \n 1 - вывести список всех сотрудников с имеющимися данными \n 2 - сумма затрат на зарплаты в месяц \n 3 - минимальная зарплата \n 4 - максимальная зарплата \n 5 - средняя зарплата всех сотрудников \n 6 - ФИО всех сотрудников");
                        int choise1 = int.Parse(Console.ReadLine());
                        switch (choise1)
                        {
                            case 1:
                                GetEmployeesInfo();
                                break;
                            case 2:
                                SumSalary();
                                break;
                            case 3:
                                MinSalary();
                                break;
                            case 4:
                                MaxSalary();
                                break;
                            case 5:
                                AvgSalary();
                                break;
                            case 6:
                                GetEmployeesFio();
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("выберите задание: \n 1 - индексация зарплат \n 2 - зарплата ниже вводимого значения \n 3 - зарплата выше вводимого значения \n 4 - через номер отдела(департамента) ");
                        int choise2 = int.Parse(Console.ReadLine());
                        switch (choise2)
                        {
                            case 1:
                                UpSalaryEmployee();
                                break;
                            case 2:
                                Selectless();
                                break;
                            case 3:
                                Selectabove();
                                break;
                            case 4:
                                Console.WriteLine("1 - Сотрудник с минимальной зарплатой \n 2 - Сотрудник с маккимальной зарплатой \n 3 - Среднюю зарплату по отделу \n 4 - Проидексировать зарплату всех сотрудников \n 5 - все данные сотрудников с определенного отдела");
                                int choise3 = int.Parse(Console.ReadLine());
                                switch (choise3)
                                {
                                    case 1:
                                        MinSalaryEmployeeWithDepartment();
                                        break;
                                    case 2:
                                        MaxSalaryEmployeeWithDepartment();
                                        break;
                                    case 3:
                                        AvgSalaryEmployeesWithDepartment();
                                        break;
                                    case 4:
                                        UpSalaryEmployeesWithDepartment();
                                        break;
                                    case 5:
                                        GetInfoAllEmployeesWithDepartment();
                                        break;
                                }
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("выберите что вы хотите сделать: \n 1 - добавить нового сотрудника \n 2 - удалить сотрудника \n 3 - вывести список удаленных сотрудников \n 4 - изменить зарплату \n 5 - изменить отдел \n 6 - вывести всю информацию о сотрудниках по отделам");
                        int choise4 = int.Parse(Console.ReadLine());
                        switch (choise4)
                        {
                            case 1:
                                AddNewEmployee();
                                break;
                            case 2:
                                DeleteEmployee();
                                break;
                            case 3:
                                ListDelEmployees();
                                break;
                            case 4:
                                ChangeSalary();
                                break;
                            case 5:
                                ChangeDepartment();
                                break;
                            case 6:
                                AllInfoByDepartment();
                                break;
                        }
                        break;
                }

                Console.WriteLine("вы хотите вернуться к выбору? (y/n)");
                string c = (Console.ReadLine());
                if (c == "y")
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    break;
                }
            }

            void GetEmployeesFio()
            {
                foreach (var emp in employee)
                {
                    Console.WriteLine(emp.FullName);
                }
            }

            void SumSalary()
            {
                foreach (var emp in employee)
                {
                    sumsalary += emp.Salary;
                }
                Console.WriteLine($"Сумма затрат на зарплаты в месяц -- {sumsalary}");
            }

            void AvgSalary()
            {
                foreach (var emp in employee)
                {
                    count++;
                    avgsalary += emp.Salary;


                }
                avgsalary /= count;
                Console.WriteLine(avgsalary);
            }

            void GetEmployeesInfo()
            {
                foreach (var emp in employee)
                {
                    Console.WriteLine($"Фио сотрудника {emp.FullName} -- департамент в котором работает сотрудник {emp.Department} -- зарплата сотрудника {emp.Salary}");
                }
            }
            void MinSalary()
            {
                Console.WriteLine($" Минимальная зарплата {employee.Min(e => e.Salary + " y " + e.FullName)}");
            }
            void MaxSalary()
            {
                Console.WriteLine($" Минимальная зарплата {employee.Max(e => e.Salary + " y " + e.FullName)}");
            }
            void UpSalaryEmployee()
            {
                Console.WriteLine("На сколько вы хотите поднять зарплату сотрудникам?");
                double upsalaryemployee = double.Parse(Console.ReadLine());
                foreach (var emp in employee)
                {
                    emp.Salary *= upsalaryemployee;
                    Console.WriteLine($"заплата у сотрудника {emp.FullName} равна {emp.Salary}");
                }
            }
            void Selectless()
            {
                Console.WriteLine("Введите число");
                int selectless = int.Parse(Console.ReadLine());
                foreach (var emp in employee)
                {
                    if (emp.Salary < selectless)
                    {
                        Console.WriteLine($"ФИО {emp.FullName} -- Зарплата сотрудника {emp.Salary}-- табельный номер сотрудника {emp.ID} ");
                    }
                }
            }
            void Selectabove()
            {
                Console.WriteLine("Введите число");
                int selectless = int.Parse(Console.ReadLine());
                foreach (var emp in employee)
                {
                    if (emp.Salary >= selectless)
                    {
                        Console.WriteLine($"ФИО {emp.FullName} -- Зарплата сотрудника {emp.Salary}-- табельный номер сотрудника {emp.ID} ");
                    }
                }
            }
            void GetInfoAllEmployeesWithDepartment()
            {
                Console.WriteLine("Введите номер отдела ");
                int selectdepartment = int.Parse(Console.ReadLine());
                foreach (var emp in employee)
                {
                    if (emp.Department == selectdepartment)
                    {
                        Console.WriteLine($"В данном отделе присутствует {emp.FullName} -- зарплата {emp.Salary} -- табельный номер {emp.ID}");
                    }
                }
            }
            void UpSalaryEmployeesWithDepartment()
            {
                Console.WriteLine("Введите номер отдела ");
                int selectdepartment1 = int.Parse(Console.ReadLine());
                Console.WriteLine("На сколько вы хотите поднять зарплату сотрудникам?");
                double upsalaryemployee = double.Parse(Console.ReadLine());
                foreach (var emp in employee)
                {
                    if (emp.Department == selectdepartment1)
                    {
                        emp.Salary *= upsalaryemployee;
                        Console.WriteLine($"заплата у сотрудника {emp.FullName} равна {emp.Salary}");
                    }
                }
            }
            void AvgSalaryEmployeesWithDepartment()
            {
                Console.WriteLine("Введите номер отдела ");
                int selectdepartment2 = int.Parse(Console.ReadLine());
                foreach (var emp in employee)
                {
                    if (emp.Department == selectdepartment2)
                    {
                        countforavg++;
                        avgsalary2 += emp.Salary;
                    }
                }

                avgsalary2 /= countforavg;
                if (selectdepartment2 < 5)
                {
                    Console.WriteLine($"Средняя зарплата по введенному вами отделу равна {avgsalary2}");
                    avgsalary2 = 0;
                    countforavg = 0;
                }
                else
                {
                    Console.WriteLine("Данного отдела нет в базе");
                    avgsalary2 = 0;
                    countforavg = 0;
                }
            }
            void MinSalaryEmployeeWithDepartment()
            {

                Console.WriteLine("Введите номер отдела");
                int selectdepartment3 = int.Parse(Console.ReadLine());
                var employeesInDepartment = employee.Where(e => e.Department == selectdepartment3);
                if (employeesInDepartment.Any())
                {
                    var employeeWithMinSalary = employeesInDepartment.OrderBy(e => e.Salary).First();
                    Console.WriteLine($"Человек с самой минимальной зарплатой в отделе {selectdepartment3}: {employeeWithMinSalary.FullName} - {employeeWithMinSalary.Salary} рублей");
                }
                else
                {
                    Console.WriteLine($"Отдел {selectdepartment3} не найден или не имеет сотрудников.");
                }
            }

            void MaxSalaryEmployeeWithDepartment()
            {

                Console.WriteLine("Введите номер отдела");
                int selectdepartment4 = int.Parse(Console.ReadLine());
                var employeesInDepartment = employee.Where(e => e.Department == selectdepartment4);
                if (employeesInDepartment.Any())
                {

                    var employeeWithMaxSalary = employeesInDepartment.OrderBy(e => e.Salary).Last();
                    Console.WriteLine($"Человек с самой максимальной зарплатой в отделе {selectdepartment4}: {employeeWithMaxSalary.FullName} - {employeeWithMaxSalary.Salary} рублей");
                }
                else
                {
                    Console.WriteLine($"Отдел {selectdepartment4} не найден или не имеет сотрудников.");
                }
            }
            void AddNewEmployee()
            {
                if (employee.Count < employee.Capacity)
                {
                    Console.WriteLine(" есть свободная ячейка");
                    Console.WriteLine("Введите ФИО сотрудника");
                    string NameNewEmployee = Console.ReadLine();
                    Console.WriteLine("Введите департамент сотрудника");
                    int DepartmentNewEmployee = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите зарплату сотрудника");
                    double SalaryNewEmployee = Convert.ToDouble(Console.ReadLine());
                    var IDlast = employee.OrderBy(e => e.ID).Last();
                    int idselect = IDlast.ID;
                    idselect += 1;
                    employee.Add(new Employees(NameNewEmployee, DepartmentNewEmployee, SalaryNewEmployee, idselect));
                    foreach (var emp in employee)
                    {
                        Console.WriteLine($"ФИО сотрудника - {emp.FullName}, Департамент - {emp.Department}, Зарплата - {emp.Salary} руб, Id - {emp.ID},");
                    }
                }
                else
                {
                    Console.WriteLine("Список полный, нет свободных ячеек!");
                }
            }
            void DeleteEmployee()
            {
                Console.WriteLine("Введите ID сотрудника которого хотите удалить");
                int index = int.Parse(Console.ReadLine());
                index -= 1;
                deletedemployee.Add(employee[index]);
                foreach (var delemp in deletedemployee)
                {
                    Console.WriteLine($"Фио удаленного сотрудника {delemp.FullName}, департамент {delemp.Department}, Зарплата{delemp.Salary},АЙДИ{delemp.ID}");
                }
                index += 1;
                foreach (var emp in employee)
                {
                    if (emp.ID == index)
                    {
                        employee.Remove(emp);
                        break;
                    }
                }
                if (employee.Count > 0)
                {
                    Console.WriteLine("Список сотрудников после удаления:");
                    foreach (var emp in employee)
                    {
                        Console.WriteLine($"{emp.ID}, {emp.FullName}, {emp.Department}, {emp.Salary} руб.");
                    }
                }
                else
                {
                    Console.WriteLine("Список сотрудников пуст.");
                }
            }
            void ListDelEmployees()
            {
                Console.WriteLine(" Список удаленных сотрудников :");
                foreach (var delemp in deletedemployee)
                {
                    Console.WriteLine($"ФИО сотрудника - {delemp.FullName}, департамент - {delemp.Department}, Зарплата - {delemp.Salary}, ID - {delemp.ID}");
                }
            }
            void ChangeSalary()
            {
                Console.WriteLine("Введите ID сотрудника которому хотите поменять зарплату");
                int indexchangesalary = int.Parse(Console.ReadLine());
                foreach (var emp in employee)
                {
                    if (emp.ID == indexchangesalary)
                    {
                        Console.WriteLine($"Введите новую зарплату сотруднику {emp.FullName}");
                        double newsalary = Convert.ToDouble(Console.ReadLine());
                        emp.Salary = newsalary;
                        Console.WriteLine($"новая зарплата сотрудника {emp.FullName} равна  - {emp.Salary} ");
                    }
                }
            }
            void ChangeDepartment()
            {
                Console.WriteLine("Введите ID сотрудника которому хотите поменять зарплату");
                int indexchangedepartment = int.Parse(Console.ReadLine());
                foreach (var emp in employee)
                {
                    if (emp.ID == indexchangedepartment)
                    {
                        Console.WriteLine($"Введите новый отдел сотруднику {emp.FullName}");
                        int newdepartment = int.Parse(Console.ReadLine());
                        emp.Department = newdepartment;
                        Console.WriteLine($"новый отдел сотрудника {emp.FullName} теперь - {emp.Department} ");
                    }
                }
            }
            void AllInfoByDepartment()
            {
                int countdepart = 0;
                foreach (var emp in employee)
                {
                    var employeesInDepartment = employee.Where(e => e.Department == countdepart);
                    if (employeesInDepartment.Any())
                    {
                        Console.WriteLine("==============================================");
                        Console.WriteLine($"|| {countdepart} отдел:  ||");
                        var employeeWithMinSalary = employeesInDepartment.OrderBy(e => e.Salary).First();
                        Console.WriteLine($"|| {employeeWithMinSalary.FullName} || {employeeWithMinSalary.Salary} ");
                        var employeeWithMaxSalary = employeesInDepartment.OrderBy(e => e.Salary).Last();
                        Console.WriteLine($"|| {employeeWithMaxSalary.FullName} || {employeeWithMaxSalary.Salary} ");
                        Console.WriteLine("==============================================");
                    }
                    countdepart++;
                }
            }
        }
    }
}
