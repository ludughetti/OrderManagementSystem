using System.Collections.Generic;
using UnityEngine;

namespace Order.Items.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Orders/Order Item")]
    public class OrderItemDataSource : ScriptableObject
    {
        public string itemName;
        public string itemDescription;
        public float basePrice;
        public Sprite icon;
        public List<AddOnDataSource> addOns;
    }
}
