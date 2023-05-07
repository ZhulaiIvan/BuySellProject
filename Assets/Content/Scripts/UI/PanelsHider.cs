using Content.Scripts.Utils;
using UnityEngine;

public class PanelsHider : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;

    private void Awake()
    {
#if UNITY_ANDROID
        _panels.Each(p => p.SetActive(true));
#endif
    }
}