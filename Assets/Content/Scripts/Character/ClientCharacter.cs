using UnityEngine;
using Zenject;

namespace Content.Scripts.Character
{
    public class ClientCharacter : MonoBehaviour
    {
        [SerializeField] private Controller _controller;
        private CharacterModel _model;
        public CharacterModel Model => _model;

        public Controller Controller => _controller;

        [Inject]
        public void Construct(CharacterModel model)
        {
            _model = model;
        }
    }
}