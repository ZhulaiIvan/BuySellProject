using Content.Scripts.Character;
using Content.Scripts.States;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Trigger
{
    [RequireComponent(typeof(BoxCollider))]
    public class MarketPlaceTrigger : MonoBehaviour
    {
        private MarketPlace _market;
        private AppStateContr _stateContr;

        [Inject]
        public void Construct(AppStateContr stateContr)
        {
            _stateContr = stateContr;
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out ClientCharacter character))
                return;

            if (!character.Controller.TryInteract()) return;
            
            Debug.Log("Player tries interact");
            _stateContr.ChangeState(AppStates.Market);
            return;
        }
    }
}