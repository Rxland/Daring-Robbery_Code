using System;
using System.Collections.Generic;
using _GAME.Code.Extentions;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Logic.Interaction.Interactables;
using _GAME.Code.StaticData;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _GAME.Code.Logic.Interaction.Safe_Deposit_Box
{
    public class SafeDeposit : MonoBehaviour
    {
        [SerializeField] private List<SafeDepositLootBox> _safeDepositLootBoxList;
        private List<SafeDepositLootBox> _safeDepositLootBoxListCanInteractWith = new List<SafeDepositLootBox>();

        private StaticDataService _staticDataService;
        private GameFactory _gameFactory;
        

        [Inject]
        private void Constructor(StaticDataService staticDataService,
                                 GameFactory gameFactory)
        {
            _staticDataService = staticDataService;
            _gameFactory = gameFactory;
        }
        
        private void Start()
        {
            SetUpDepositLootBoxes();
            SpawnLootInBoxes();
        }

        private void SetUpDepositLootBoxes()
        {
            foreach (SafeDepositLootBox safeDepositLootBox in _safeDepositLootBoxList)
            {
                safeDepositLootBox.CanInteract = false;
            }

            int lootBoxesAmount = Mathf.CeilToInt(GameExtensions.CalculatePercentageOfTheNumber(
                _staticDataService.SafeDepositStaticData.CanInteractWithDepositBoxesAmountPercentage,_safeDepositLootBoxList.Count));
            
            List<SafeDepositLootBox> safeDepositLootBoxListCopy = new List<SafeDepositLootBox>(_safeDepositLootBoxList);
            
            
            for (int i = 0; i < lootBoxesAmount; i++)
            {
                SafeDepositLootBox randomSafeDepositLootBox =
                    safeDepositLootBoxListCopy[Random.Range(0, safeDepositLootBoxListCopy.Count)];

                randomSafeDepositLootBox.CanInteract = true;
                
                _safeDepositLootBoxListCanInteractWith.Add(randomSafeDepositLootBox);
                safeDepositLootBoxListCopy.Remove(randomSafeDepositLootBox);
            }
        }
        private void SpawnLootInBoxes()
        {
            SafeDepositStaticData safeDepositStaticData = _staticDataService.SafeDepositStaticData;
            
            foreach (SafeDepositLootBox safeDepositLootBox in _safeDepositLootBoxListCanInteractWith)
            {
                foreach (Transform spawnLootPoint in safeDepositLootBox.SpawnLootPoints)
                {
                    Treasure newTreasure = _gameFactory.SpawnTreasureByPrefab(
                        safeDepositStaticData.SafeDepositRandomInBoxTreasures[Random.Range(0, safeDepositStaticData.SafeDepositRandomInBoxTreasures.Count)]);
                    newTreasure.transform.parent = spawnLootPoint.transform;
                    newTreasure.transform.position = spawnLootPoint.position;

                    safeDepositLootBox.TreasuresInsideTheBox.Add(newTreasure);
                    
                    newTreasure.CanInteract = false;
                    newTreasure.InteractableDoneEvent += () =>
                    {
                        safeDepositLootBox.DeleteTreasuresInsideTheBox(newTreasure);
                    };
                }
            }
        }
    }
}