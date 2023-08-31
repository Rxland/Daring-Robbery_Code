using _GAME.Code.Data;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.StaticData.Weapon_Stuff;
using _GAME.Code.Types.Weapon_Stuff;
using InfimaGames.LowPolyShooterPack;
using Zenject;

namespace _GAME.Code.Features
{
    public class WeaponsFeature : IService
    {
        [Inject] private SaveFeature _saveFeature;
        [Inject] private StaticDataService _staticDataService;
        [Inject] private GameFactory _gameFactory;

        public WeaponSlotType SelectedToChangeWeaponSlotType;

        public void SpawnWeaponForPreview(WeaponTypeName weaponTypeName, WeaponSkinName weaponSkinName)
        {
            Weapon weapon = _gameFactory.SpawnWeapon(weaponTypeName, weaponSkinName);
            
            
        }
        
        public void EquipWeapon(WeaponsSaveData weaponsSaveData)
        {
            WeaponsSaveData previusEqippedWeaponsSaveData = GetEquippedWeaponsSaveDataBySlotType(SelectedToChangeWeaponSlotType);
            previusEqippedWeaponsSaveData.IsEquipped = false;
            previusEqippedWeaponsSaveData.WeaponSlotType = WeaponSlotType.None;
            
            weaponsSaveData.WeaponSlotType = SelectedToChangeWeaponSlotType;
            weaponsSaveData.IsEquipped = true;

            _saveFeature.Save();
        }
        
        public WeaponStaticData GetWeaponStaticData(WeaponTypeName waponTypeName, WeaponSkinName weaponSkinName)
        {
            foreach (WeaponStaticData weaponStaticData in _staticDataService.WeaponStaticDataList)
            {
                if (weaponStaticData.weaponTypeName == waponTypeName &&
                    weaponStaticData.WeaponSkinName == weaponSkinName)
                {
                    return weaponStaticData;
                }
            }
            return null;
        }

        public WeaponsSaveData GetWeaponsSaveData(WeaponTypeName waponTypeName, WeaponSkinName weaponSkinName)
        {
            foreach (WeaponsSaveData weaponsSaveData in _saveFeature.SaveData.InventorySaveData.WeaponsSaveDataList)
            {
                if (weaponsSaveData.WeaponTypeName == waponTypeName &&
                    weaponsSaveData.WeaponSkinName == weaponSkinName)
                {
                    return weaponsSaveData;
                }
            }
            return null;
        }
        
        public WeaponsSaveData GetEquippedWeaponsSaveDataBySlotType(WeaponSlotType weaponSlotType)
        {
            WeaponsSaveData returnWeaponsSaveData = null;
            
            foreach (WeaponsSaveData weaponsSaveData in _saveFeature.SaveData.InventorySaveData.WeaponsSaveDataList)
            {
                if (weaponsSaveData.IsEquipped && weaponsSaveData.WeaponSlotType == weaponSlotType)
                {
                    returnWeaponsSaveData = weaponsSaveData;
                }
            }
            return returnWeaponsSaveData;
        }
        
        public WeaponStaticData GetEquippedWeaponStaticDataBySlotType(WeaponSlotType WeaponSlotType)
        {
            WeaponStaticData returnWeaponStaticData = null;
            WeaponsSaveData weaponsSaveData = GetEquippedWeaponsSaveDataBySlotType(WeaponSlotType);
            
            returnWeaponStaticData = GetWeaponStaticData(weaponsSaveData.WeaponTypeName, weaponsSaveData.WeaponSkinName);

            return returnWeaponStaticData;
        }
    }
}