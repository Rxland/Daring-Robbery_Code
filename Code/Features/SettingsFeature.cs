using System;
using _GAME.Code.Data;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Types;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Features
{
    public class SettingsFeature : IService
    {
        [Inject] private SaveFeature _saveFeature;
        [ReadOnly] public SettingsSaveData SettingsSaveData; 
        
        public void InitGameSettings()
        {
            SettingsSaveData = _saveFeature.SaveData.SettingsSaveData; 
            
            AudioListener.volume = SettingsSaveData.MainVolume;
            UpdateCurrentLanguage();
            UpdateGraphics();
        }

        public void ChangeMainVolume(float volume)
        {
            SettingsSaveData.MainVolume = volume;
            AudioListener.volume = volume;
            
            _saveFeature.Save();
        }

        public void ChangeGraphics(GraphicsType graphicsType)
        {
            SettingsSaveData.GraphicsType = graphicsType;

            UpdateGraphics();
            
            _saveFeature.Save();
        }
        
        public void ChangeLanguage(LanguageType languageType)
        {
            SettingsSaveData.LanguageType = languageType;

            UpdateCurrentLanguage();
            
            _saveFeature.Save();
        }

        private void UpdateCurrentLanguage()
        {
            switch (SettingsSaveData.LanguageType)
            {
                case LanguageType.Russian:
                    I2.Loc.LocalizationManager.CurrentLanguage = "Russian";
                    break;
                case LanguageType.English:
                    I2.Loc.LocalizationManager.CurrentLanguage = "English";
                    break;
                case LanguageType.Turkish:
                    I2.Loc.LocalizationManager.CurrentLanguage = "Turkish";
                    break;
            }
        }

        private void UpdateGraphics()
        {
            QualitySettings.SetQualityLevel((int)SettingsSaveData.GraphicsType, false);
        }
    }
}