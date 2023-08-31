using _GAME.Code.Infrastructure.Services;
using _GAME.Code.UI;
using Zenject;

namespace _GAME.Code.Features
{
    public class HudUiFeature : IService
    {
        [Inject] private HudUiRef hudUiRef;
        [Inject] private InventoryFeature _inventoryFeature;
        [Inject] private RunTimeDataFeature _runTimeDataFeature;
        [Inject] private StaticDataService _staticDataService;
        
        public void Init()
        {
            _inventoryFeature.OnItemAddedEvent += UpdateStolenItemsAmountText;
            _inventoryFeature.OnItemRemovedEvent += UpdateStolenItemsAmountText;
            _inventoryFeature.OnAddedCurrencyEvent += UpdateStolenItemsAmountText;
            
            UpdateStolenItemsAmountText();
        }
        
        private void UpdateStolenItemsAmountText()
        {
            hudUiRef.StolenMoneyBagsAmountText.text = $"{_runTimeDataFeature.RunTimeData.TreasureDataList.Count}/{_staticDataService.ReturnPlayerStaticData.MaxBackPacks}";
            hudUiRef.MoneyAmountContainerRef.AmountText.text = _runTimeDataFeature.RunTimeData.InGameDollarusAmount.ToString();
        }

        public void SetActiveCrosshair(bool activeMode)
        {
            hudUiRef.CrosshairImg.gameObject.SetActive(activeMode);
        }
    }
}