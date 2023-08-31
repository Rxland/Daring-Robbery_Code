using System;
using _GAME.Code.Data;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Infrastructure.Services;
using Zenject;

namespace _GAME.Code.Features
{
    public class InventoryFeature : IService
    {
        public Action OnItemAddedEvent;
        public Action OnItemRemovedEvent;
        public Action OnAddedCurrencyEvent;
        
        [Inject] private RunTimeDataFeature _runTimeDataFeature;
        [Inject] private StaticDataService _staticDataService;
        [Inject] private EnvFactory _envFactory;

        public bool HaveBackBackFreeSlot()
        {
            if (_runTimeDataFeature.RunTimeData.TreasureDataList.Count >= _staticDataService.ReturnPlayerStaticData.MaxBackPacks)
                return false;

            return true;
        }
        
        public TreasureData GetFirstTreasureDataFromList()
        {
            return _runTimeDataFeature.RunTimeData.TreasureDataList[0];
        }
        public void AddTreasure(TreasureData treasureData)
        {
            _runTimeDataFeature.RunTimeData.TreasureDataList.Add(treasureData);
            
            _envFactory.Level.Van.UpdateActiveBackBackIndicator();
            
            OnItemAddedEvent?.Invoke();
        }
        public void RemoveTreasure(TreasureData treasureData)
        {
            _runTimeDataFeature.RunTimeData.TreasureDataList.Remove(treasureData);
         
            _envFactory.Level.Van.UpdateActiveBackBackIndicator();
            
            OnItemRemovedEvent?.Invoke();
        }
        public int GetInGameDollarusAmount(int amount)
        {
            return _runTimeDataFeature.RunTimeData.InGameDollarusAmount;
        }
        public void AddInGameDollarusAmount(int amount)
        {
            _runTimeDataFeature.RunTimeData.InGameDollarusAmount += amount;
            OnAddedCurrencyEvent?.Invoke();
        }
    }
}