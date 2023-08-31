using _GAME.Code.Data;
using _GAME.Code.Features;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Types.Weapon_Stuff;
using Zenject;

namespace _GAME.Code.UI.Shop
{
    public class ShopSaveHandler : IService
    {
        private SaveFeature _saveFeature;
        
        [Inject]
        private void Constructor(SaveFeature saveFeature)
        {
            _saveFeature = saveFeature;
        }
        
        public WeaponsSaveData GetWeaponsSaveDataByNameType(WeaponTypeName weaponTypeName)
        {
            foreach (WeaponsSaveData weaponsSaveData in _saveFeature.SaveData.InventorySaveData.WeaponsSaveDataList)
            {
                if (weaponsSaveData.WeaponTypeName == weaponTypeName)
                    return weaponsSaveData;
            }
            return null;
        }
    }
}