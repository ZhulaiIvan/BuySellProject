using Content.Scripts.Inventory;
using Content.Scripts.States;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Trigger
{
    public class MarketPlace : MonoBehaviour
    {
        private AppStateContr _state;
        private MarketPlaceScreen _screen;
        private InventoryItem[] _items;

        [Inject]
        public void Construct(AppStateContr state, MarketPlaceScreen screen)
        {
            _state = state;
            _state.State.Changed += OnStateUpdated;
            _screen = screen;
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
            _state.State.Changed -= OnStateUpdated;
            _screen.OnScreenHide();
        }

        private void InitMarket()
        {
            _screen.OnScreenShow();
        }
    }

    public class MarketPlaceScreen : MenuScreen
    {
        
    }
}