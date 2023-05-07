using Content.Scripts.Inventory;
using UnityEngine;

namespace Content.Scripts.UI.Screens
{
    [CreateAssetMenu(fileName = "MarketConfig", menuName = "BuySell/Market/Config")]
    public class MarketConfig : ScriptableObject
    {
        [SerializeField] private InventoryItemConfig[] _items;
        public InventoryItemConfig[] Items => _items;
    }
}   