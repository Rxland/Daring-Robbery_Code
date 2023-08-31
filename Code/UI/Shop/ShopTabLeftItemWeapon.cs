using _GAME.Code.Data;
using _GAME.Code.StaticData.Weapon_Stuff;
using Sirenix.OdinInspector;

namespace _GAME.Code.UI.Shop
{
    public class ShopTabLeftItemWeapon : ShopTabItemBase
    {
        [ReadOnly] public WeaponStaticData WeaponStaticData;
        [ReadOnly] public WeaponsSaveData WeaponsSaveData;
    }
}