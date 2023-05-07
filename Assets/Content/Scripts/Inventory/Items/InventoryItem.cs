using UnityEngine;

namespace Content.Scripts.Inventory
{
    public class InventoryItem
    {
        protected InventoryItemConfig _config;
        public InventoryItemConfig Config => _config;

        public InventoryItem(InventoryItemConfig config)
        {
            _config = config;
        }
    }
}