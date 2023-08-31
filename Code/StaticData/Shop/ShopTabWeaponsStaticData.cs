using System.Collections.Generic;
using _GAME.Code.Types;
using UnityEngine;

namespace _GAME.Code.StaticData.Shop
{
    [CreateAssetMenu(fileName = "Shop Tab Weapons Static Data", menuName = "Static Data/Shop/Shop Tabs/Weapon Types")]
    public class ShopTabWeaponsStaticData : ScriptableObject
    {
        public ShopTabType ShopTabType;

        public List<ShopTabWeaponItem> ShopTabWeaponItemList;
    }
}