using _GAME.Code.StaticData.Weapon_Stuff;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME.Code.UI.Shop
{
    public class ShopBottomTabItem : ShopTabItemBase
    {
        [Header("ShopBottomTabItem")]
        
        [SerializeField] private MoneyAmountContainerRef _moneyAmountContainerRef;

        [ReadOnly] public WeaponAttachmentStaticData WeaponAttachmentStaticData;
        
        public void SetPriceText(int price)
        {
            _moneyAmountContainerRef.AmountText.text = price.ToString();
        }
    }
}