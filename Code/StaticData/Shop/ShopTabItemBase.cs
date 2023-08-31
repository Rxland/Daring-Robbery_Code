using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME.Code.StaticData.Shop
{
    [Serializable]
    public class ShopTabItemBase
    {
        public string Name;
        [PreviewField]
        public Sprite IconSprite;
    }
}