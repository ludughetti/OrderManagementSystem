using System.Collections.Generic;
using UnityEngine;

namespace Order.Items.ScriptableObjects
{
    [CreateAssetMenu(fileName = "OrderItemDefinition", menuName = "Scriptable Objects/Order/OrderItemDefinition")]
    public class OrderItemDataSource : ScriptableObject
    {
        public string itemName;
        public string itemDescription;
        public float basePrice;
        public Sprite icon;
        public List<AddOnDataSource> addOns;
    }
}
