using _GAME.Code.Features;
using _GAME.Code.Types;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _GAME.Code.UI.Windows
{
    public class SettingsWindow : WindowBase
    {
        [SerializeField] private Button _secondCloseButton;
        [SerializeField] private Slider _gameVolumeSlider;
        [SerializeField] private TMP_Dropdown _graphicsDropdown;
        [SerializeField] private TMP_Dropdown _languageDropdown;
        
        
        [Inject] private SettingsFeature _settingsFeature;

        protected override void Awake()
        {
            base.Awake();
            _secondCloseButton.onClick.AddListener(() => SetActiveWindow(false));
            _gameVolumeSlider.onValueChanged.AddListener(OnGameVolumeSliderChanged);
            _graphicsDropdown.onValueChanged.AddListener(OnGraphicsDropdownChanged);
            _languageDropdown.onValueChanged.AddListener(OnLanguageDropdownChanged);
        }

        protected override void OnWindowOpen()
        {
            _gameVolumeSlider.value = _settingsFeature.SettingsSaveData.MainVolume;
            _graphicsDropdown.value = (int)_settingsFeature.SettingsSaveData.GraphicsType;
            _languageDropdown.value = (int)_settingsFeature.SettingsSaveData.LanguageType;
        }

        
        private void OnGameVolumeSliderChanged(float value)
        {
            _settingsFeature.ChangeMainVolume(value);
        }

        private void OnGraphicsDropdownChanged(int id)
        {
            switch (id)
            {
                case 0:
                    _settingsFeature.ChangeGraphics(GraphicsType.Low);
                    break;
                case 1:
                    _settingsFeature.ChangeGraphics(GraphicsType.Medium);
                    break;
                case 2:
                    _settingsFeature.ChangeGraphics(GraphicsType.Ultra);
                    break;
            }
        }
        
        private void OnLanguageDropdownChanged(int id)
        {
            switch (id)
            {
                case 0:
                    _settingsFeature.ChangeLanguage(LanguageType.Russian);
                    break;
                case 1:
                    _settingsFeature.ChangeLanguage(LanguageType.English);
                    break;
                case 2:
                    _settingsFeature.ChangeLanguage(LanguageType.Turkish);
                    break;
            }
        }
    }
}