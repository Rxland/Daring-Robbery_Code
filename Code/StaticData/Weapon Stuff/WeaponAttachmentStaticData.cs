using _GAME.Code.Logic.Weapon_Stuff;
using _GAME.Code.Types;
using _GAME.Code.Types.Weapon_Stuff;
using UnityEngine;
using UnityEngine.Serialization;

namespace _GAME.Code.StaticData.Weapon_Stuff
{
    [CreateAssetMenu(fileName = "Weapon Attachment Data", menuName = "Static Data/Weapon Stuff/Weapon Attachment")]
    public class WeaponAttachmentStaticData : ShopBuyItemStaticDataBase
    {
        [FormerlySerializedAs("WeaponAttachmentType")] 
        public WeaponAttachmentTabType weaponAttachmentTabType;
        public WeaponAttachmentName WeaponAttachmentName;
        public WeaponAttachment WeaponAttachmentPrefab;
    }
}