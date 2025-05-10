using UnityEngine;
using User;
using User.Clients;

namespace Notifications
{
    public class ClientObserver : IObserver
    {
        private Client _client;

        public ClientObserver(Client client)
        {
            _client = client;
        }
        
        public void Update(Order.Order order)
        {
            Debug.Log($"Sending notification to client { _client.UserId }. Order status is: { order.Status }");
        }
    }
}
