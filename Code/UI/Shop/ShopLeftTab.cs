using System.Collections.Generic;
using _GAME.Code.Data;
using _GAME.Code.Features;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Logic.Weapon_Stuff;
using _GAME.Code.UI.Windows;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _GAME.Code.UI.Shop
{
    public class ShopLeftTab : MonoBehaviour
    {
        [SerializeField] private ShopWindow _shopWindow;
        [SerializeField] private Transform _weaponPrefabPositionPoint;
        [Space]
        
        [SerializeField] private Transform _shopLeftTabItemSpawnContainer;
        [ReadOnly] public List<ShopTabLeftItemWeapon> ShopLeftTabItems;
        [ReadOnly] [ShowInInspector] private ShopTabLeftItemWeapon _equippedShopTabLeftItemWeapon;
        
        private StaticDataService _staticDataService;
        private UiFactory _uiFactory;
        private GameFactory _gameFactory;
        private WeaponPreview _weaponPreview;
        private ShopSaveHandler _shopSaveHandler;
        public SaveFeature _saveFeature;

        [Inject]
        private void Constructor(StaticDataService staticDataService, 
                                UiFactory uiFactory, 
                                GameFactory gameFactory,
                                WeaponPreview weaponPreview,
                                SaveFeature saveFeature,
                                ShopSaveHandler shopSaveHandler
                                )
        {
            _staticDataService = staticDataService;
            _uiFactory = uiFactory;
            _gameFactory = gameFactory;
            _weaponPreview = weaponPreview;
            _saveFeature = saveFeature;
            _shopSaveHandler = shopSaveHandler;
        }

        public void RenderLeftTabs()
        {
            ShopLeftTabItems = _uiFactory.SpawnLeftTabWeaponsItems(_shopLeftTabItemSpawnContainer);
            
            SetUpSpawnedShopTabItems();
            UpdateItems();
        }

        private void UpdateItems()
        {
            UpdateItemsWithSaves();
            UpdateItemsWithStaticData();
        }
        
        private void SetUpSpawnedShopTabItems()
        {
            foreach (ShopTabLeftItemWeapon shopTabItem in ShopLeftTabItems)
            {
                shopTabItem.Show();
                shopTabItem.TabClickButton.onClick.AddListener(() => TabItemClickAction(shopTabItem));
                // shopTabItem.TabClickButton.onClick.AddListener(UpdateItems);
            }
        }

        private void TabItemClickAction(ShopTabLeftItemWeapon shopTabItemBase)
        {
            if (_shopWindow.SpawnedWeapon)
                Destroy(_shopWindow.SpawnedWeapon.gameObject);
            
            _shopWindow.SpawnedWeapon = _gameFactory.SpawnWeaponForShopUi(shopTabItemBase.WeaponStaticData.WeaponPrefab, _weaponPrefabPositionPoint);
            _shopWindow.SpawnedWeapon.WeaponUi.Canvas.worldCamera = _weaponPreview.CameraPreview;

            SelectWeapon(shopTabItemBase);
            InitWeaponAttachmentButtons();
            UpdateItems();
        }

        private void SelectWeapon(ShopTabLeftItemWeapon shopTabItemBase)
        {
            foreach (ShopTabLeftItemWeapon shopTabLeftItemWeapon in ShopLeftTabItems)
            {
                if (shopTabLeftItemWeapon == shopTabItemBase)
                {
                    shopTabItemBase.WeaponsSaveData.IsSelected = true;
                }
                else
                {
                    shopTabItemBase.WeaponsSaveData.IsSelected = false;
                }
            }
            _saveFeature.Save();
        }
        
        private void InitWeaponAttachmentButtons()
        {
            ShowWeaponUiPart();
            
            foreach (WeaponAttachmentUiPart weaponUiWeaponAttachmentUiPart in _shopWindow.SpawnedWeapon.WeaponUi
                         .WeaponAttachmentUiParts)
            {
                weaponUiWeaponAttachmentUiPart.attachmentUiButtonRef.Button.onClick.AddListener(() =>
                {
                    _shopWindow.ShopBottomTab.RenderWeaponItems(weaponUiWeaponAttachmentUiPart.AttachmentType);
                    HideWeaponUiPart(weaponUiWeaponAttachmentUiPart);
                });
            }
        }

        private void UpdateItemsWithSaves()
        {
            WeaponsSaveData weaponsSavesDataForEquippedItem = null;
            
            foreach (ShopTabLeftItemWeapon shopTabLeftItemWeapon in ShopLeftTabItems)
            {
                WeaponsSaveData weaponsSaveData = _shopSaveHandler.GetWeaponsSaveDataByNameType(shopTabLeftItemWeapon.WeaponStaticData.weaponTypeName);

                if (weaponsSaveData.IsSelected)
                {
                    _equippedShopTabLeftItemWeapon = shopTabLeftItemWeapon;
                    weaponsSavesDataForEquippedItem = weaponsSaveData;
                }
                shopTabLeftItemWeapon.WeaponsSaveData = weaponsSaveData;
                shopTabLeftItemWeapon.SetUnlockMode(weaponsSaveData.IsOpend);
            }
            _shopWindow.ShowBuyEquipButtonByType(weaponsSavesDataForEquippedItem, _equippedShopTabLeftItemWeapon.WeaponStaticData.OpenPrice);
            _equippedShopTabLeftItemWeapon.SetItemEquipMode(weaponsSavesDataForEquippedItem.BuyEquipState);
        }

        private void UpdateItemsWithStaticData()
        {
            foreach (ShopTabLeftItemWeapon shopTabLeftItemWeapon in ShopLeftTabItems)
            {
                shopTabLeftItemWeapon.SetPriceText(shopTabLeftItemWeapon.WeaponStaticData.OpenPrice);
            }
        }
        
        private void HideWeaponUiPart(WeaponAttachmentUiPart weaponAttachmentUiPart)
        {
            foreach (WeaponAttachmentUiPart weaponUiWeaponAttachmentUiPart in _shopWindow.SpawnedWeapon.WeaponUi
                         .WeaponAttachmentUiParts)
            {
                if (weaponUiWeaponAttachmentUiPart == weaponAttachmentUiPart)
                    weaponUiWeaponAttachmentUiPart.attachmentUiButtonRef.Hide();
                else if (!weaponUiWeaponAttachmentUiPart.attachmentUiButtonRef.gameObject.activeSelf)
                    weaponUiWeaponAttachmentUiPart.attachmentUiButtonRef.Show();
            }
        }
        private void ShowWeaponUiPart()
        {
            foreach (WeaponAttachmentUiPart weaponUiWeaponAttachmentUiPart in _shopWindow.SpawnedWeapon.WeaponUi
                         .WeaponAttachmentUiParts)
            {
                weaponUiWeaponAttachmentUiPart.attachmentUiButtonRef.Show();
            }
        }
    }
}