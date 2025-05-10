using System.Collections.Generic;
using System.Linq;
using Notifications;
using Order.Items;
using UnityEngine;
using User;
using User.Clients;

namespace Order
{
    public class Order
    {
        public OrderType Type { get; set; }
        public Client Client { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; } = new();
        
        private List<IObserver> _observers = new();
        
        public virtual void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public float GetOrderTotalPrice()
        {
            return Items.Sum(i => i.GetTotalPrice());
        }

        public void UpdateStatus(OrderStatus status)
        {
            Status = status;
            NotifyObservers();
        }

        public void AttachObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void DetachObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        private void NotifyObservers()
        {
            Debug.Log("Notifying observers...");
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
