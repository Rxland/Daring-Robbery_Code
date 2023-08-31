using System.Collections.Generic;
using _GAME.Code.Types;
using UnityEngine;

namespace _GAME.Code.StaticData.Shop
{
    [CreateAssetMenu(fileName = "Shop Tab Attachments Static Data", menuName = "Static Data/Shop/Shop Tabs/Attachment Types")]
    public class ShopTabAttachmentsStaticData : ScriptableObject
    {
        public ShopTabType ShopTabType;

        public List<ShopTabAttachmentItem> ShopTabAttachmentItemList;
    }
}