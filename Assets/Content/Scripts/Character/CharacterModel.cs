﻿using Content.Scripts.Data;
using Content.Scripts.Inventory;

namespace Content.Scripts.Character
{
    public class CharacterModel
    {
        private ObservableInt _money;
        private PlayerInventory _inventory;

        public ObservableInt Money => _money;
        public PlayerInventory Inventory => _inventory;

        public CharacterModel(PlayerInventory inventory)
        {
            _money = new (1000);

            _inventory = inventory;
        }
    }
}