using System.Collections.Generic;
using System.Linq;
using Order;
using User.Clients;
using User.Employees;

namespace Notifications
{
    public class NotificationManager
    {
        private ClientManager _clientManager;
        private EmployeeManager _employeeManager;

        private Dictionary<OrderType, List<IObserver>> _observersPerOrderId = new ();
        private List<Order.Order> _orders = new ();

        public NotificationManager(ClientManager clientManager, EmployeeManager employeeManager)
        {
            _clientManager = clientManager;
            _employeeManager = employeeManager;
        }

        public void ObserveOrderProgress(Order.Order order)
        {
            var clientObserver = new ClientObserver(_clientManager.GetActiveClient(order.Client.UserId));
            var employeeObserver = new EmployeeObserver(_employeeManager.GetActiveEmployee());
            
            order.AttachObserver(clientObserver);
            order.AttachObserver(employeeObserver);
            
            _observersPerOrderId.Add(order.Type, new List<IObserver>() {clientObserver, employeeObserver});
            _orders.Add(order);
        }

        public void FinalizeProcess(OrderType orderType)
        {
            var observersPerOrderId = _observersPerOrderId[orderType];
            var order = _orders.FirstOrDefault(order => order.Type == orderType);
            
            foreach (var observer in observersPerOrderId)
                order?.DetachObserver(observer);
        }
    }
}
