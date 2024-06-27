using Employee.Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Maui.Models
{
    public static class EmployeeRepository
    {
        public static List<Employees> _employees = new List<Employees>()
        {
			new Employees {EmployeeId=1,Name="John Smith", Number="02 9988 2211",Address="1 Code Lane"},
            new Employees {EmployeeId=2,Name="Sue White", Number="03 8899 2255",Address="16 Bit Way"},
            new Employees {EmployeeId=3,Name = "Bob O’Bits", Number = "05 7788 2255",Address = "8 Silicon Road" },
        };

        public static List<Employees> GetEmployees() => _employees;

        public static Employees GetEmployeesById(int employeeId)
        {
            var employees =  _employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            if (employees != null)
            {
                return new Employees
                {
                    EmployeeId = employeeId,
                    Name = employees.Name,
                    Number = employees.Number,
                    Address = employees.Address,
                };
            }

            return null;
        }

        public static void UpdateEmployees(int employeeId, Employees employees)
        {
            if (employeeId != employees.EmployeeId)
            {
                return;
            }

            var employeesToUpdate = _employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            if (employeesToUpdate != null)
            {
                employeesToUpdate.Name = employees.Name;
                employeesToUpdate.Number = employees.Number;
                employeesToUpdate.Address = employees.Address;
            }
        }
    }
}
