using System;
using UnityEngine;

namespace Content.Scripts.Trigger
{
    public abstract class MenuScreen
    {
        [SerializeField] private GameObject _screen;
        
        public virtual void OnScreenShow(Action complete = null)
        {
            _screen.SetActive(true);    
            complete?.Invoke();
        }

        public virtual void OnScreenHide(Action complete = null)
        {
            _screen.SetActive(false);
            complete?.Invoke();
        }
    }
}