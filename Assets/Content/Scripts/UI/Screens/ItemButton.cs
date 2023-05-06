using System;
using Content.Scripts.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Scripts.UI.Screens
{
    public class ItemButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        [Space]
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Image _image;
        public void Init(InventoryItem item)
        {
            _title.text = item.Config.Title;
            _price.text = item.Config.Price.ToString();
            _image.sprite = item.Config.Sprite;
        }

        public void OnClick(Action onClick)
        {
            _button.onClick.AddListener(() => onClick?.Invoke());
        }

        public void Destroy()
        {
            _button.onClick.RemoveAllListeners();
            Destroy(this);
        }
    }
}