using System;
using System.Collections.Generic;
using UnityEngine;

namespace _GAME.Code.Data
{
    [Serializable]
    public class SaveData
    {
        [Header("Currency")]
        public int DollarusAmount;
        
        [Header("Bag")]
        public int MaxBagsSlots;

        [Header("Inventory")]
        public InventorySaveData InventorySaveData;

        [Header("Player Progress")] 
        public PlayerProgressData PlayerProgressData;

        [Header("Settings")] 
        public SettingsSaveData SettingsSaveData;
    }
}