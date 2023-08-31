using _GAME.Code.Types.Weapon_Stuff;
using InfimaGames.LowPolyShooterPack;
using UnityEngine;

namespace _GAME.Code.StaticData.Weapon_Stuff
{
    [CreateAssetMenu(fileName = "Weapon Static Data", menuName = "Static Data/Weapon Stuff/Weapon")]
    public class WeaponStaticData : ShopBuyItemStaticDataBase
    {
        public WeaponTypeName weaponTypeName;
        public WeaponSkinName WeaponSkinName;
        public Weapon WeaponPrefab;
    }
}