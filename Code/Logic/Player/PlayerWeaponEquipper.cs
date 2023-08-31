using System.Collections.Generic;
using _GAME.Code.Data;
using _GAME.Code.Features;
using _GAME.Code.Logic.Character.Ref;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Player
{
    public class PlayerWeaponEquipper : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterRef _playerCharacterRef;
        
        [Inject] private WeaponsFeature _weaponsFeature;
        
        
        public void SetEquippedWeapons()
        {
            List<WeaponBehaviour> newWeapons = new List<WeaponBehaviour>();
            
            for (int i = 0; i < _playerCharacterRef.Inventory.weapons.Count; i++)
            {
                WeaponBehaviour inventoryWeapon = _playerCharacterRef.Inventory.weapons[i];
                Weapon weapon = (Weapon)inventoryWeapon;
            
                WeaponsSaveData weaponsSaveData = _weaponsFeature.GetWeaponsSaveData(weapon.weaponTypeName, weapon.WeaponSkinName);
                
                if (weaponsSaveData == null || !weaponsSaveData.IsEquipped)
                {
                    continue;
                }
                else
                {
                    newWeapons.Add(weapon);
                }
            }
            _playerCharacterRef.Inventory.weapons = new List<WeaponBehaviour>(newWeapons);
            _playerCharacterRef.Inventory.Equip(0);
            _playerCharacterRef.Character.EquipStartIE(0);
        }
    }
}