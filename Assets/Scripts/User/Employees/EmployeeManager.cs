using System.Collections.Generic;
using UnityEngine;

namespace User.Employees
{
    public class EmployeeManager
    {
        private List<Employee> _activeEmployees = new ();

        public EmployeeManager()
        {
            // Mocked employee 
            var newEmployee = new Employee("Employee 1", "Address 123", "1234 5678");
            _activeEmployees.Add(newEmployee);
        }

        public Employee GetActiveEmployee()
        {
            return _activeEmployees[0];
        }
    }
}
