using System;
using System.Collections.Generic;
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

        public void InitUI()
        {
            _config.Items.Each(item =>
            {
                ItemButton button = Instantiate(_buttonPrefab, _content);
                button.Init(item);
                button.OnClick(() =>
                {
                    Debug.Log("Button clicked");
                });
                
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