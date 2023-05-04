using Content.Scripts.Data;
using UnityEngine;

namespace Content.Scripts.Character
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "BuySell/Configs/Character")]
    public class CharacterData : ScriptableObject
    {
        public ObservableInt Money = new(1000);
    }
}