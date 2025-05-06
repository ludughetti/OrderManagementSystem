using UnityEngine;

namespace Order.Items.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Orders/Add-on")]
    public class AddOnDataSource : ScriptableObject
    {
        public string addOnName;
        public string addOnDescription;
        public float price;
        public Sprite icon;
    }
}
