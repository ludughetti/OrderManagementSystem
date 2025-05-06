using UnityEngine;

namespace Order.Items.ScriptableObjects
{
    [CreateAssetMenu(fileName = "AddOnDefinition", menuName = "Scriptable Objects/Order/AddOnDefinition")]
    public class AddOnDataSource : ScriptableObject
    {
        public string addOnName;
        public string addOnDescription;
        public float price;
        public Sprite icon;
    }
}
