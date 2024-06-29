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
        // Static list that includes employee details which are included when application
        // is run. 
        public static List<Employees> _employees = new List<Employees>()
        {
			new Employees {EmployeeId=1,Name="John Smith", Number="02 9988 2211",Address="1 Code Lane"},
            new Employees {EmployeeId=2,Name="Sue White", Number="03 8899 2255",Address="16 Bit Way"},
            new Employees {EmployeeId=3,Name = "Bob O’Bits", Number = "05 7788 2255",Address = "8 Silicon Road" },
        };

        // Method to obtain employees
        public static List<Employees> GetEmployees() => _employees;


        public static Employees GetEmployeesById(int employeeId)
        {
            // Find Id of employee
            var employees =  _employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            if (employees != null)
            {

                // Return new employee to repository
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

        // Method used to update employee information 
        public static void UpdateEmployees(int employeeId, Employees employees)
        {
            // Id of employee matches user selected Id. 
            if (employeeId != employees.EmployeeId)
            {
                return;
            }

            // Find employee to update
            var employeesToUpdate = _employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            if (employeesToUpdate != null)
            {
                // Update name, number and address of employee
                employeesToUpdate.Name = employees.Name;
                employeesToUpdate.Number = employees.Number;
                employeesToUpdate.Address = employees.Address;
            }
        }

        // Method used to add new employee to list
        public static void AddEmployee(Employees employees)
        {
            var maxId = _employees.Max(x => x.EmployeeId);
            employees.EmployeeId = maxId + 1;
            _employees.Add(employees);
        }

        // Method used to delete employee from list
        public static void DeleteEmployee(int employeeId)
        {
            var employee = _employees.FirstOrDefault(x => x.EmployeeId == employeeId); 
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}
