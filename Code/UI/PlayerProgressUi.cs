using _GAME.Code.Features;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _GAME.Code.UI
{
    public class PlayerProgressUi : MonoBehaviour
    {
        public Image PlayerAvatarImg;
        public Image PlayerLevelProgressFilledImg;
        public TextMeshProUGUI PlayerNameText;
        public TextMeshProUGUI PlayerLevelText;

        [Inject] private PlayerProgressFeature _playerProgressFeature;
        [Inject] private SaveFeature _saveFeature;


        public void Init()
        {
            PlayerNameText.text = _saveFeature.SaveData.PlayerProgressData.Name;
            PlayerLevelText.text = _saveFeature.SaveData.PlayerProgressData.Level.ToString();
            PlayerLevelProgressFilledImg.fillAmount = (float)_saveFeature.SaveData.PlayerProgressData.CurrentProgress / (float)_playerProgressFeature.LevelProgressToNextLevel;
        }
    }
}