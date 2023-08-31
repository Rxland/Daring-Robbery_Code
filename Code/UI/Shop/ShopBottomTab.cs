using System.Collections.Generic;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Types.Weapon_Stuff;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _GAME.Code.UI.Shop
{
    public class ShopBottomTab : MonoBehaviour
    {
        [SerializeField] private ShopLeftTab _shopLeftTab;
        [SerializeField] private Transform _itemsSpawnContainer;
        [Space]
        
        public WeaponTabType WeaponTabType;
        public WeaponAttachmentTabType WeaponAttachmentTabType;
        [Space]
        
        [ReadOnly] public List<ShopBottomTabItem> ShopTabItems;
        
        private StaticDataService _staticDataService;
        private UiFactory _uiFactory;
        
        [Inject]
        private void Constructor(StaticDataService staticDataService, UiFactory uiFactory)
        {
            _staticDataService = staticDataService;
            _uiFactory = uiFactory;
        }
        
        public void RenderWeaponItems(WeaponAttachmentTabType weaponAttachmentTabType)
        {
            TryClearShopTabItems();
            
            ShopTabItems = _uiFactory.SpawnListShopBottomTabItems(weaponAttachmentTabType, _itemsSpawnContainer);
            
            SetUpShopTabItems();
        }

        private void TryClearShopTabItems()
        {
            if (ShopTabItems.Count == 0) return;
             
            for (int i = 0; i < ShopTabItems.Count; i++)
            {
                Destroy(ShopTabItems[i].gameObject);
            }
            ShopTabItems.Clear();
        }

        private void SetUpShopTabItems()
        {
            foreach (ShopBottomTabItem shopBottomTabItem in ShopTabItems)
            {
                shopBottomTabItem.Show();
                shopBottomTabItem.TabClickButton.onClick.AddListener(() => OnAttachmentButtonClick(shopBottomTabItem));
            }
        }

        private void OnAttachmentButtonClick(ShopBottomTabItem shopBottomTabItem)
        {
            // CODE
        }
    }
}