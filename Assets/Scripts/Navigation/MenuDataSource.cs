using UnityEngine;

namespace Navigation
{
    [CreateAssetMenu(fileName = "MenuDataSource", menuName = "Scriptable Objects/MenuDataSource")]
    public class MenuDataSource : ScriptableObject
    {
        [SerializeField] private string menuId;
        
        public NavigationMenu DataInstance { get; set; }

        public string GetMenuId()
        {
            return menuId;
        }
    }
}
