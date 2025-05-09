using UnityEngine;

namespace Order.DTO
{
    public class ElementCardData
    {
        public string Name { get; }
        public string Description { get; }
        public Sprite Icon { get; }
        public string Id { get; }

        public ElementCardData(string name, string description, Sprite icon, string id)
        {
            Name = name;
            Description = description;
            Icon = icon;
            Id = id;
        }
    }
}
