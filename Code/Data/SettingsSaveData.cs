using System;
using _GAME.Code.Types;

namespace _GAME.Code.Data
{
    [Serializable]
    public class SettingsSaveData
    {
        public float MainVolume;
        public LanguageType LanguageType;
        public GraphicsType GraphicsType;
    }
}