using System;
using _GAME.Code.Types.Weapon_Stuff;

namespace _GAME.Code.UI.Shop
{
    [Serializable]
    public class WeaponAttachmentUiPart
    {
        public WeaponAttachmentTabType AttachmentType;
        public AttachmentUiButtonRef attachmentUiButtonRef;
    }
}