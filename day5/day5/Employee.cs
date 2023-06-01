using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5
{
    internal class Employees
    {
        public string _fullName;
        public int _department;
        public double _salary;
        public int _id;

        public Employees(string fullname, int department, double salary, int id)
        {
            _fullName = fullname;
            _department = department;
            _salary = salary;
            _id = id;

        }
        public string FullName
        {
            get => _fullName;
            set => _fullName = value;
        }
        public int Department
        {
            get => _department;
            set => _department = value;
        }
        public double Salary
        {
            get => _salary;
            set => _salary = value;
        }
        public int ID
        {
            get => _id;
            set => _id = value;
        }
    }
}
