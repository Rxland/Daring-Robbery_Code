using _GAME.Code.Data;
using DG.Tweening;
using UnityEngine;

namespace _GAME.Code.Logic.Interaction.Interactables
{
    public class Treasure : Interactable
    {
        public int MinPrice;
        public int MaxPrice;
        [Space] 
        [SerializeField] private bool AddCurrencyImmediately;

        
        public override bool CheckCanInteract()
        {
            if (!CanInteract || (!InventoryFeature.HaveBackBackFreeSlot() && !AddCurrencyImmediately))
                return false;

            return true;
        }
        
        public override void Interact()
        {
            
        }

        public override void Interact(Transform whoInteractT)
        {
            if (!CanInteract) return;

            CanInteract = false;

            InteractableDoneEvent?.Invoke();
            
            SpawnPickUpEffect();

            if (!AddCurrencyImmediately)
            {
                TreasureData newTreasureData = new TreasureData();
                newTreasureData.PriceMin = MinPrice;
                newTreasureData.PriceMax = MaxPrice;
                
                InventoryFeature.AddTreasure(newTreasureData);
            }
            else
            {
                int randomStolenItemInGameDolluras = Random.Range(MinPrice, MaxPrice);
                InventoryFeature.AddInGameDollarusAmount(randomStolenItemInGameDolluras);
            }
            
            transform.DOScale(0f, 0.3f).SetEase(Ease.InOutBack).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}