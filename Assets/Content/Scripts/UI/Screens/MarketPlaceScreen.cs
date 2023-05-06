using System;
using System.Collections.Generic;
using Content.Scripts.Character;
using Content.Scripts.Trigger;
using Content.Scripts.Utils;
using UnityEngine;
using Zenject;

namespace Content.Scripts.UI.Screens
{
    public class MarketPlaceScreen : MenuScreen
    {
        [Header("Prefabs")] 
        [SerializeField] private ItemButton _buttonPrefab;
        
        [Space]
        [SerializeField] private Transform _content;
        [SerializeField] private MarketConfig _config;

        private List<ItemButton> _buttons = new ();
        
        private CharacterModel _characterModel;

        [Inject]
        public void Construct(CharacterModel model)
        {
            _characterModel = model;
        }

        public void InitUI(MarketType type)
        {
            InitItems(type);
        }
        
        private void InitItems(MarketType type)
        {
            switch (type)
            {
                case MarketType.None:
                    break;
                case MarketType.Buy:
                    InitFromMarketConfig();
                    break;
                case MarketType.Sell:
                    InitFromCharacterModel();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private void InitFromCharacterModel()
        {
            _characterModel.Inventory.Items.Each(item =>
            {
                ItemButton button = Instantiate(_buttonPrefab, _content);
                button.Init(item);
                button.OnClick(() => { Debug.Log("Button clicked"); });

                _buttons.Add(button);
            });
        }

        private void InitFromMarketConfig()
        {
            _config.Items.Each(item =>
            {
                ItemButton button = Instantiate(_buttonPrefab, _content);
                button.Init(item);
                button.OnClick(() => { Debug.Log("Button clicked"); });

                _buttons.Add(button);
            });
        }

        public override void OnScreenHide(Action complete = null)
        {
            base.OnScreenHide(complete);
            _buttons.Each(b => b.Destroy());   
            _buttons.Clear();
        }
    }
}