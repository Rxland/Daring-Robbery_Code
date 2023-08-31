using System;
using System.Collections.Generic;
using _GAME.Code.Types.Weapon_Stuff;
using _GAME.Code.UI.Windows;
using UnityEngine;

namespace _GAME.Code.Data
{
    [Serializable]
    public class WeaponsSaveData
    {
        public bool IsOpend;
        public bool IsSelected;
        public bool IsEquipped;
        public BuyEquipState BuyEquipState;
        [Space] 
        
        public WeaponTypeName WeaponTypeName;
        public WeaponSkinName WeaponSkinName;
        public WeaponSlotType WeaponSlotType;
        [Space]
        
        public List<WeaponAttachmentSaveData> WeaponAttachmentsList;
    }
}