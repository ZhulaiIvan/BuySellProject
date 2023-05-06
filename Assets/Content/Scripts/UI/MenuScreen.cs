using System;
using UnityEngine;

namespace Content.Scripts.UI
{
    public abstract class MenuScreen : MonoBehaviour
    {
        [SerializeField] protected GameObject _screen;
        
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