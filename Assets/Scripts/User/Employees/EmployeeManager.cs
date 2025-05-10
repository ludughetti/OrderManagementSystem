using System.Collections.Generic;
using UnityEngine;

namespace User.Employees
{
    public class EmployeeManager : MonoBehaviour
    {
        private List<Employee> _activeEmployees = new List<Employee>();

        private void Start()
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
