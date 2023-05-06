using Content.Scripts.Inventory;
using Content.Scripts.States;
using Content.Scripts.UI.Screens;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Trigger
{
    public class MarketPlace : MonoBehaviour
    {
        [SerializeField] private MarketPlaceScreen _screen;
        [SerializeField] private MarketType _type;
        
        private AppStateContr _state;
        private InventoryItem[] _items;
        private bool _isMarketInit = false;

        [Inject]
        public void Construct(AppStateContr state)
        {
            _state = state;
            _state.State.Changed += OnStateUpdated;
        }

        private void OnStateUpdated(byte state)
        {
            switch ((AppStates)state)
            {
                case AppStates.Play:
                    CloseMarket();
                    break;
                case AppStates.Market:
                    InitMarket();
                    break;
            }
        }

        private void CloseMarket()
        {
            if (!_isMarketInit) return;
            
            _state.State.Changed -= OnStateUpdated;
            _screen.OnScreenHide();
        }

        private void InitMarket()
        {
            _isMarketInit = true;
            _screen.OnScreenShow(() =>
            {
                _screen.InitUI(_type);
            });
        }
    }

    public enum MarketType
    {
        None,
        Buy,
        Sell
    }
}