using Content.Scripts.Data;
using Content.Scripts.Inventory;
using UnityEngine;

namespace Content.Scripts.Character
{
    public class CharacterModel
    {
        private ObservableInt _money;
        private PlayerInventory _inventory;

        public CharacterModel(PlayerInventory inventory)
        {
            _money = new (1000);

            _inventory = inventory;
            Debug.Log($"{_inventory}");
        }
    }
}