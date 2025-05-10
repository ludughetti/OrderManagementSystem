using Order.Items.ScriptableObjects;
using UnityEngine;

namespace Order.Items
{
    public class AddOn
    {
        public string AddOnName { get; private set; }
        public string AddOnDescription { get; private set; }
        public float Price { get; set; }
        public Sprite Icon { get; private set; }

        // Initialization for UI display
        public AddOn(AddOnDataSource addOnDataSource)
        {
            AddOnName = addOnDataSource.addOnName;
            AddOnDescription = addOnDataSource.addOnDescription;
            Price = addOnDataSource.price;
            Icon = addOnDataSource.icon;
        }

        public AddOn(string addOnName, string addOnDescription, float price, Sprite icon)
        {
            AddOnName = addOnName;
            AddOnDescription = addOnDescription;
            Price = price;
            Icon = icon;
        }
    }
}
