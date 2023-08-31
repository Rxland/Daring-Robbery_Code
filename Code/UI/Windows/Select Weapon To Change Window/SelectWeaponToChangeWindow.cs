using System.Collections.Generic;
using _GAME.Code.Features;
using _GAME.Code.UI.Top_Navigation;
using UnityEngine;
using Zenject;

namespace _GAME.Code.UI.Windows.Select_Weapon_To_Change_Window
{
    public class SelectWeaponToChangeWindow : WindowBase
    {
        [SerializeField] private List<SelectWeaponToChangeButton> _selectWeaponToChangeButtonList;

        [Inject] private MainMenuWindowsController _mainMenuWindowsController;
        [Inject] private WeaponsFeature _weaponsFeature;
        
        protected override void OnWindowOpen()
        {
            base.OnWindowOpen();
            InitButtons();
        }
        
        private void InitButtons()
        {
            foreach (SelectWeaponToChangeButton selectWeaponToChangeButton in _selectWeaponToChangeButtonList)
            {
                selectWeaponToChangeButton.Button.onClick.RemoveAllListeners();
                selectWeaponToChangeButton.Button.onClick.AddListener(() =>
                {
                    _mainMenuWindowsController.OpenWindowByWindowType(WindowsType.Inventory);
                    _weaponsFeature.SelectedToChangeWeaponSlotType = selectWeaponToChangeButton.WeaponSlotType;
                });

                selectWeaponToChangeButton.WeaponImg.sprite = _weaponsFeature.GetEquippedWeaponStaticDataBySlotType(selectWeaponToChangeButton.WeaponSlotType).Icon;
            }
        }
    }
}