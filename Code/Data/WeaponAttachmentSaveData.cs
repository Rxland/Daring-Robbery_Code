using System;
using _GAME.Code.Types;
using _GAME.Code.Types.Weapon_Stuff;

namespace _GAME.Code.Data
{
    [Serializable]
    public class WeaponAttachmentSaveData
    {
        public bool IsOpend;
        public WeaponAttachmentTabType weaponAttachmentTabType;
        public WeaponAttachmentName WeaponAttachmentName;
    }
}