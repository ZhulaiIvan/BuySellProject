using Content.Scripts.Character;
using Content.Scripts.States;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Trigger
{
    [RequireComponent(typeof(BoxCollider))]
    public class MarketPlaceTrigger : MonoBehaviour
    {
        [SerializeField] private MarketPlace _market;
        [SerializeField] private GameObject _hint;
        
        private AppStateContr _stateContr;
        private ClientCharacter _character;

        [Inject]
        public void Construct(AppStateContr stateContr)
        {
            _stateContr = stateContr;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out ClientCharacter character))
                return;
            _character = character;
            _hint.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out ClientCharacter character))
                return;

            _character = null;
            _hint.SetActive(false);
        }

        private void Update()
        {
            TryInteract();
        }

        private void TryInteract()
        {
            if (_character == null) return;
            if (!_character.Controller.TryInteract()) return;

            Debug.Log("Player tries to interact");
            //_hint.SetActive(false);
            _stateContr.State.Value = (byte)AppStates.Market;
            _market.InitMarket();
        }
    }
}