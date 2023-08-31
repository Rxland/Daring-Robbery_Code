using _GAME.Code.Data;
using UnityEngine;

namespace _GAME.Code.Logic.Interaction.Interactables
{
    public class VanInteractable : Interactable
    {
        public override void Interact(Transform whoInteractT)
        {
            if (RunTimeDataFeature.RunTimeData.TreasureDataList.Count == 0) return;

            TreasureData treasureData = InventoryFeature.GetFirstTreasureDataFromList();
            
            int randomStolenItemInGameDolluras = Random.Range(treasureData.PriceMin, treasureData.PriceMax);
            
            InventoryFeature.AddInGameDollarusAmount(randomStolenItemInGameDolluras);
            InventoryFeature.RemoveTreasure(treasureData);
            
            EnvFactory.Level.ExitHeistCar.UpdateActiveExitHeistIndicator();
            
            ThrowBag(whoInteractT);
        }

        public override void Interact()
        {
            
        }

        private void ThrowBag(Transform whoInteractT)
        {
            Vector3 bagPos = whoInteractT.position + whoInteractT.up * StaticDataService.ReturnPlayerStaticData.BagSpawnYPosOffset;
            Backpack bag = GameFactory.SpawnBag(bagPos);
            bag.Rigidbody.AddForce(whoInteractT.forward * StaticDataService.ReturnPlayerStaticData.BagForceSpeed, ForceMode.Impulse);
        }
    }
}