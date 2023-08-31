using System.Collections.Generic;
using _GAME.Code.StaticData.Weapon_Stuff;
using UnityEngine;
using UnityEngine.Serialization;

namespace _GAME.Code.StaticData.Shop
{
    [CreateAssetMenu(fileName = "Shop Static Data", menuName = "Static Data/Shop/Shop Static Data")]
    public class ShopStaticData : ScriptableObject
    {
        [Header("Shop Left Tab")] 
        public Code.UI.Shop.ShopTabItemBase shopLeftTabItemBasePrefab;
        
        [Header("Shop Bottom Tab")]
        public Code.UI.Shop.ShopBottomTabItem shopBottomTabItemPrefab;

        [Header("Left Tab Weapons Items")] 
        public List<WeaponStaticData> WeaponStaticDataList;
    }
}