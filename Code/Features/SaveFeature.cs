using _GAME.Code.Data;
using _GAME.Code.Infrastructure.Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME.Code.Features
{
    public class SaveFeature : MonoBehaviour, IService
    {
        public SaveData SaveData;
        public bool UseSavesForDebug;
        public SaveData SaveDataForDebug;

        private void Awake()
        {
            if (UseSavesForDebug)
                SaveData = SaveDataForDebug;
        }

        [Button]
        public void Save()
        {
            ES3.Save("SaveData", SaveData);
        }
        
        [Button]
        public SaveData Load()
        {
            SaveData = ES3.Load<SaveData>("SaveData", SaveData);
            return SaveData;
        }
    }
}