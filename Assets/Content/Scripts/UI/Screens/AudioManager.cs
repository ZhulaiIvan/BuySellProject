using System;
using System.Linq;
using UnityEngine;

namespace Content.Scripts.UI.Screens
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioData[] _audioDatas;
        public void Play(MusicType type)
        {
            if (_audioDatas.Any(c => c.ContainsKey(type))) 
                _audioDatas.First(c => c.ContainsKey(type)).Source.Play();
        }
    }
    
    [Serializable]
    public struct AudioData
    {
        public AudioSource Source;
        public MusicType Type;

        public bool ContainsKey(MusicType type)
        {
            return Type == type;
        }
    }

    public enum MusicType
    {
        Purchase,
        Movement
    }
}