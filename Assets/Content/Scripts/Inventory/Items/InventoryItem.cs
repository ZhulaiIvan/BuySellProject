using UnityEngine;

namespace Content.Scripts.Inventory
{
    public abstract class InventoryItem : MonoBehaviour
    {
        [SerializeField] private InventoryItemConfig _config;

        public InventoryItemConfig Config => _config;
    }
}