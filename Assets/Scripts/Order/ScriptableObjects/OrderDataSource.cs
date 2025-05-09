using System.Collections.Generic;
using Order.Items.ScriptableObjects;
using UnityEngine;

namespace Order.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Orders/Order")]
    public class OrderDataSource : ScriptableObject
    {
        public string orderName;
        public string orderDescription;
        public Sprite orderIcon;
        public OrderType type;
        public List<OrderItemDataSource> orderItems;
    }
}
