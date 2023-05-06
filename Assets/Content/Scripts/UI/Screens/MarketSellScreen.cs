﻿using System;
using System.Collections.Generic;
using Content.Scripts.Character;
using Content.Scripts.States;
using Content.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Content.Scripts.UI.Screens
{
    public class MarketSellScreen : MarketScreen
    {
        [Header("Prefabs")]
        [SerializeField] private ItemButton _buttonPrefab;

        [Space] [SerializeField] private Transform _content;

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
            
            _exitButton.onClick.AddListener(_stateContr.ReturnBack);
        }

        private void InitItems()
        {
           UpdateFromMarketConfig();
        }

        private void UpdateFromMarketConfig()
        {
            _characterModel.Inventory.Items.Each(item =>
            {
                ItemButton button = Instantiate(_buttonPrefab, _content);
                button.Init(item);
                button.OnClick(() =>
                {
                    _characterModel.Money.Value += item.Config.Price;
                    _characterModel.Inventory.DeleteItem(item);

                    Update();
                });

                _buttons.Add(button);
            });
        }

        public override void OnScreenHide(Action complete = null)
        {
            base.OnScreenHide(complete);
            Clear();
        }
        
        private void Update()
        {
            Clear();
        }

        private void Clear()
        {
            _buttons.Each(button => button.Destroy());
            _buttons.Clear();
        }
    }
}