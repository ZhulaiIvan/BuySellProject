using System;
using System.Collections.Generic;

namespace Content.Scripts.Inventory
{
    public class PlayerInventory
    {
        private List<InventoryItemConfig> _items = new();

        public InventoryItemConfig[] Items => _items.ToArray();
        
        public event Action OnInventoryUpdated;

        public void AddItem(InventoryItemConfig itemConfig)
        {
            _items.Add(itemConfig);

            OnInventoryUpdated?.Invoke();
        }

        public void DeleteItem(InventoryItemConfig itemConfig)
        {
            if (!_items.Contains(itemConfig)) return;
            
            _items.Remove(itemConfig);
            OnInventoryUpdated?.Invoke();
        }
    }
}