using UnityEngine;
using User;

namespace Notifications
{
    public class EmployeeObserver : IObserver
    {
        private Employee _employee;

        public EmployeeObserver(Employee employee)
        {
            _employee = employee;
        }
        
        public void Update(Order.Order order)
        {
            Debug.Log($"Sending notification to employee { _employee.UserId }. Order status is: { order.Status }");
        }
    }
}
