using Content.Scripts.Inventory;
using Content.Scripts.States;
using Content.Scripts.UI.Screens;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Trigger
{
    public class MarketPlace : MonoBehaviour
    {
        [SerializeField] private MarketScreen _screen;
        
        private AppStateContr _state;
        private InventoryItem[] _items;

        [Inject]
        public void Construct(AppStateContr state)
        {
            _state = state;
            Subscribe();
        }

        private void Subscribe()
        {
            _state.State.Changed += OnStateUpdated;
        }

        private void OnStateUpdated(byte state)
        {
            switch ((AppStates)state)
            {
                case AppStates.Play:
                    CloseMarket();
                    break;
            }
        }

        private void CloseMarket()
        {
            _screen.OnScreenHide();
        }

        public void InitMarket()
        {
            _screen.OnScreenShow(() =>
            {
                _screen.InitUI();
            });
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
        
        private void Unsubscribe()
        {
            _state.State.Changed -= OnStateUpdated;
        }
    }
}