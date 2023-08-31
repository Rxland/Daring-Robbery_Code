using _GAME.Code.Types;
using _GAME.Code.Types.Weapon_Stuff;
using UnityEngine;
using UnityEngine.Serialization;

namespace _GAME.Code.Logic.Weapon_Stuff
{
    public class WeaponAttachment : MonoBehaviour
    {
        [FormerlySerializedAs("WeaponAttachmentType")] public WeaponAttachmentTabType weaponAttachmentTabType;
        public WeaponAttachmentName WeaponAttachmentName;
    }
}