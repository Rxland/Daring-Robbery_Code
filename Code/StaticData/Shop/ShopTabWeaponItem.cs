using System;
using System.Collections.Generic;
using _GAME.Code.StaticData.Weapon_Stuff;
using _GAME.Code.Types.Weapon_Stuff;

namespace _GAME.Code.StaticData.Shop
{
    [Serializable]
    public class ShopTabWeaponItem : ShopTabItemBase
    {
        public WeaponTabType WeaponTabType;
        public List<WeaponStaticData> WeaponStaticDataList;
    }
}