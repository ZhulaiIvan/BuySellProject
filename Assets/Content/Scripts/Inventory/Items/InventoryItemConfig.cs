using UnityEngine;

namespace Content.Scripts.Inventory
{
    public abstract class InventoryItemConfig : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _title;
        [SerializeField] private int _price;

        public Sprite Sprite => _sprite;
        public string Title => _title;
        public int Price => _price;
    }
}
