using System.Collections.Generic;
using _GAME.Code.Data;
using _GAME.Code.Features;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.StaticData.Weapon_Stuff;
using _GAME.Code.Types.Weapon_Stuff;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _GAME.Code.UI.Windows.Invenotory
{
    public class InventoryWindow : WindowBase
    {
        [SerializeField] private InventoryItem _inventoryItemPrefab;
        [SerializeField] private Transform _inventoryItemsContainer;
        [ReadOnly] [ShowInInspector] private List<InventoryItem> _spawnedInventoryItems = new();

        private InventorySaveData _inventorySaveData;
        
        [Inject] private WeaponsFeature _weaponsFeature;
        [Inject] private SaveFeature _saveFeature;
        [Inject] private UiFactory _uiFactory;
        [Inject] private MainMenuWindowsController _mainMenuWindowsController;

        protected override void OnWindowOpen()
        {
            base.OnWindowOpen();

            Init();
            SpawnInventoryItems();
        }

        private void Init()
        {
            _inventorySaveData = _saveFeature.SaveData.InventorySaveData;
        }
        
        private void SpawnInventoryItems()
        {
            Clear();

            foreach (WeaponsSaveData weaponsSaveData in _inventorySaveData.WeaponsSaveDataList)
            {
                WeaponStaticData weaponStaticData = _weaponsFeature.GetWeaponStaticData(weaponsSaveData.WeaponTypeName, weaponsSaveData.WeaponSkinName);
                InventoryItem newInventoryItem = _uiFactory.SpawnInventoryItem(_inventoryItemPrefab, _inventoryItemsContainer);

                newInventoryItem.StoredWeaponsSaveData = weaponsSaveData;
                newInventoryItem.StoredWeaponStaticData = weaponStaticData;
                
                newInventoryItem.ItemImg.sprite = weaponStaticData.Icon;
                newInventoryItem.ItemNameText.text = weaponStaticData.ItemName;
                
                _spawnedInventoryItems.Add(newInventoryItem);
            }
            UpdateInventoryItemsEquipState();
        }
        
        public void UpdateInventoryItemsEquipState()
        {
            foreach (InventoryItem spawnedInventoryItem in _spawnedInventoryItems)
            {
                switch (spawnedInventoryItem.StoredWeaponsSaveData.WeaponSlotType)
                {
                    case WeaponSlotType.None:
                        spawnedInventoryItem.MainWeaponEquipedImg.gameObject.SetActive(false);
                        spawnedInventoryItem.SecondaryWeaponEquipedImg.gameObject.SetActive(false);
                        break;
                    case WeaponSlotType.MainWeapons:
                        spawnedInventoryItem.MainWeaponEquipedImg.gameObject.SetActive(true);
                        break;
                    case WeaponSlotType.SecondaryWeapon:
                        spawnedInventoryItem.SecondaryWeaponEquipedImg.gameObject.SetActive(true);
                        break;
                }
            }
        }
        
        private void Clear()
        {
            if (_spawnedInventoryItems.Count == 0) return;
            
            for (int i = 0; i < _spawnedInventoryItems.Count; i++)
            {
                InventoryItem inventoryItem = _spawnedInventoryItems[i];
                Destroy(inventoryItem.gameObject);
            }
            _spawnedInventoryItems.Clear();
        }
    }
}