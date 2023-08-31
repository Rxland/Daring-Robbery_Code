using _GAME.Code.Data;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.UI.Buttons;
using _GAME.Code.UI.Shop;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _GAME.Code.UI.Windows
{
    public class ShopWindow : WindowBase
    {
        public ShopLeftTab ShopLeftTab;
        public ShopBottomTab ShopBottomTab;

        [Sirenix.OdinInspector.ReadOnly] public Weapon SpawnedWeapon;

        [Header("Buttons")] 
        public ButtonWithText BuyButton;
        public Button EquipButton;
        public Button EquipedButton;
        
        [Inject] private StaticDataService _staticDataService;

        
        private void Start()
        {
            ShopLeftTab.RenderLeftTabs();
        }
        
        public void ShowBuyEquipButtonByType(WeaponsSaveData weaponsSaveData, int price = 0)
        {
            BuyButton.gameObject.SetActive(false);
            EquipButton.gameObject.SetActive(false);
            EquipedButton.gameObject.SetActive(false);
            
            switch (weaponsSaveData.BuyEquipState)
            {
                case BuyEquipState.Buy:
                    BuyButton.gameObject.SetActive(true);
                    BuyButton.ButtonText.text = price.ToString();
                    break;
                case BuyEquipState.Equip:
                    EquipButton.gameObject.SetActive(true);
                    break;
                case BuyEquipState.Equiped:
                    EquipedButton.gameObject.SetActive(true);
                    break;
            }
        }
    }
}