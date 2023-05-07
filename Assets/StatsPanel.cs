using Content.Scripts.Character;
using TMPro;
using UnityEngine;
using Zenject;

public class StatsPanel : MonoBehaviour
{
   [SerializeField] private TMP_Text _moneyLabel;
   private CharacterModel _model;

   [Inject]
   public void Construct(CharacterModel model)
   {
      _model = model;
   }

   private void Start()
   {
      _model.Money.Changed += OnMoneyChanged;
   }

   private void OnMoneyChanged(int money)
   {
      _moneyLabel.text = money.ToString();
   }

   private void OnDisable()
   {
      _model.Money.Changed -= OnMoneyChanged;
   }

   private void OnDestroy()
   {
      _model.Money.Changed -= OnMoneyChanged;
   }
}
