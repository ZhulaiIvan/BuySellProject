using System;
using System.Collections.Generic;

namespace Content.Scripts.Inventory
{
    public class PlayerInventory
    {
        private List<InventoryItem> _items = new();

        public InventoryItem[] Items => _items.ToArray();
        public event Action OnInventoryUpdated;
        public void AddItem(InventoryItem itemConfig)
        {
            _items.Add(itemConfig);

            OnInventoryUpdated?.Invoke();
        }

        public void DeleteItem(InventoryItem itemConfig)
        {
            if (!_items.Contains(itemConfig)) return;
            
            _items.Remove(itemConfig);
            OnInventoryUpdated?.Invoke();
        }
    }
}