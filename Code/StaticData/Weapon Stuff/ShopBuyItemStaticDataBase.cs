using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME.Code.StaticData.Weapon_Stuff
{
    public class ShopBuyItemStaticDataBase : ScriptableObject
    {
        public string ItemName;
        [PreviewField]
        public Sprite Icon;
        public int OpenPrice;
    }
}