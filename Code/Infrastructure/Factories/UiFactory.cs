using System.Collections.Generic;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.StaticData.Shop;
using _GAME.Code.StaticData.Weapon_Stuff;
using _GAME.Code.Types.Weapon_Stuff;
using _GAME.Code.UI;
using _GAME.Code.UI.Canvases;
using _GAME.Code.UI.Shop;
using _GAME.Code.UI.Windows.Invenotory;
using UnityEngine;
using Zenject;
using ShopTabItemBase = _GAME.Code.UI.Shop.ShopTabItemBase;

namespace _GAME.Code.Infrastructure.Factories
{
    public class UiFactory : IService
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private StaticDataService _staticDataService;
        [Inject] private CanvasesController _canvasesController;
        [Inject] private GameFactory _gameFactory;

        
        public List<ShopTabLeftItemWeapon> SpawnLeftTabWeaponsItems(Transform spawnParent)
        {
            List<ShopTabLeftItemWeapon> spawnedItems = new();
            
            foreach (WeaponStaticData weaponStaticData in _staticDataService.ShopStaticData.WeaponStaticDataList)
            {
                ShopTabLeftItemWeapon newShopTabItemBase = _diContainer.InstantiatePrefabForComponent<ShopTabLeftItemWeapon>(_staticDataService.ShopStaticData.shopLeftTabItemBasePrefab, spawnParent);
                newShopTabItemBase.WeaponStaticData = weaponStaticData;
                newShopTabItemBase.SetTabNameText(weaponStaticData.ItemName);
                newShopTabItemBase.SetTabIconSprite(weaponStaticData.Icon);
                
                spawnedItems.Add(newShopTabItemBase);
            }
            
            return spawnedItems;
        }

        public List<ShopTabItemBase> SpawnShopWeaponTabItems(Transform spawnParent)
        {
            ShopTabWeaponsStaticData shopTabWeaponsStaticData = _staticDataService.ShopTabWeaponsStaticData;

            List<ShopTabItemBase> spawnedShopLeftTabItem = new();

            foreach (ShopTabWeaponItem shopTabWeaponItem in shopTabWeaponsStaticData.ShopTabWeaponItemList)
            {
                ShopTabItemBase newShopTabItemBase = _diContainer.InstantiatePrefabForComponent<ShopTabItemBase>(_staticDataService.ShopStaticData.shopLeftTabItemBasePrefab, spawnParent);
                newShopTabItemBase.SetTabNameText(shopTabWeaponItem.Name);
                newShopTabItemBase.SetTabIconSprite(shopTabWeaponItem.IconSprite);
                
                spawnedShopLeftTabItem.Add(newShopTabItemBase);
            }
            return spawnedShopLeftTabItem;
        }
        public List<ShopTabItemBase> SpawnShopAttachmentTabItems(Transform spawnParent)
        {
            ShopTabAttachmentsStaticData shopTabAttachmentsStaticData = _staticDataService.ShopTabAttachmentsStaticData;

            List<ShopTabItemBase> spawnedShopLeftTabItem = new();

            foreach (ShopTabAttachmentItem shopTabAttachmentItem in shopTabAttachmentsStaticData.ShopTabAttachmentItemList)
            {
                ShopTabItemBase newShopTabItemBase = _diContainer.InstantiatePrefabForComponent<ShopTabItemBase>(_staticDataService.ShopStaticData.shopLeftTabItemBasePrefab, spawnParent);
                newShopTabItemBase.SetTabNameText(shopTabAttachmentItem.Name);
                newShopTabItemBase.SetTabIconSprite(shopTabAttachmentItem.IconSprite);
                
                spawnedShopLeftTabItem.Add(newShopTabItemBase);
            }
            return spawnedShopLeftTabItem;
        }

        public List<ShopBottomTabItem> SpawnListShopBottomTabItems(WeaponAttachmentTabType weaponAttachmentTabType, Transform spawnParent)
        {
            List<ShopBottomTabItem> shopBottomTabItemList = new();
            
            foreach (WeaponAttachmentStaticData weaponAttachmentStaticData in _staticDataService.ReturnWeaponAttachmentStaticDataList(weaponAttachmentTabType))
            {
                ShopBottomTabItem newShopTabItemBase = _diContainer.InstantiatePrefabForComponent<ShopBottomTabItem>(_staticDataService.ShopStaticData.shopBottomTabItemPrefab, spawnParent);
                newShopTabItemBase.SetTabNameText(weaponAttachmentStaticData.ItemName);
                newShopTabItemBase.SetTabIconSprite(weaponAttachmentStaticData.Icon);
                newShopTabItemBase.SetPriceText(weaponAttachmentStaticData.OpenPrice);
                newShopTabItemBase.WeaponAttachmentStaticData = weaponAttachmentStaticData;
                
                shopBottomTabItemList.Add(newShopTabItemBase);
            }
            return shopBottomTabItemList;
        }

        public void SpawnHitEnemyIndicator(Vector3 pos, bool isKilled)
        {
            CanvasBase canvasBase = _canvasesController.GetCanvas(CanvasType.GameCanvas);

            HitEnemyIndicator newHitIndicator = GameObject.Instantiate(_staticDataService.ReturnPlayerStaticData.HitEnemyIndicator,
                canvasBase.transform);
            
            newHitIndicator.Init(_gameFactory.PlayerCamera, pos);
            
            if (isKilled)
                newHitIndicator.SetIndicatorColorToKilled();
            
            GameObject.Destroy(newHitIndicator, 0.1f);
        }
        
        public InventoryItem SpawnInventoryItem(InventoryItem inventoryItemPrefab, Transform inventoryItemsContainer)
        {
            return _diContainer.InstantiatePrefabForComponent<InventoryItem>(inventoryItemPrefab, inventoryItemsContainer);
        }
    }
}