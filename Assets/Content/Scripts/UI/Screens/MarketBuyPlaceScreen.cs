﻿using System;
using System.Collections.Generic;
using Content.Scripts.Character;
using Content.Scripts.Inventory;
using Content.Scripts.States;
using Content.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Content.Scripts.UI.Screens
{
    public class MarketBuyPlaceScreen : MarketScreen
    {
        [Header("Prefabs")]
        [SerializeField] private ItemButton _buttonPrefab;

        [Space] [SerializeField] private Transform _content;
        [SerializeField] private MarketConfig _config;

        [Space] 
        [SerializeField] private Button _exitButton;

        private readonly List<ItemButton> _buttons = new();

        private CharacterModel _characterModel;
        private AppStateContr _stateContr;

        [Inject]
        public void Construct(CharacterModel model, AppStateContr stateContr)
        {
            _characterModel = model;
            _stateContr = stateContr;
        }

        public override void InitUI()
        {
            InitItems();
            
            _exitButton.onClick.AddListener(() => _stateContr.ChangeState(AppStates.Play));
        }

        private void InitItems()
        {
           UpdateFromMarketConfig();
        }

        private void UpdateFromMarketConfig()
        {
            _config.Items.Each(item =>
            {
                ItemButton button = Instantiate(_buttonPrefab, _content);
                InventoryItem inventoryItem = new InventoryItem(item);
                button.Init(inventoryItem);
                
                button.OnClick(() =>
                {
                    if (_characterModel.Money.Value < inventoryItem.Config.Price) return;
                    
                    _characterModel.Money.Value -= inventoryItem.Config.Price;
                    _characterModel.Inventory.AddItem(inventoryItem);

                    _manager.Play(MusicType.Purchase);
                    
                    UpdateUI();
                });

                _buttons.Add(button);
            });
        }

        public override void OnScreenHide(Action complete = null)
        {
            Clear(); 
            base.OnScreenHide(complete);
        }
        
        private void UpdateUI()
        {
            Clear();
            UpdateFromMarketConfig();
        }

        private void Clear()
        {
            _buttons.Each(button => button.Destroy());
            _buttons.Clear();
        }
    }

    public abstract class MarketScreen : MenuScreen
    {
        [SerializeField] protected AudioManager _manager;
        public abstract void InitUI();
    }
}