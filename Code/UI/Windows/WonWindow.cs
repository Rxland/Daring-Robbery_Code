using _GAME.Code.Features;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _GAME.Code.UI.Windows
{
    public class WonWindow : WindowBase
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _youRobberedText;
        
        [SerializeField] private Transform _moneyContainer;
        [SerializeField] private Transform _goldContainer;

        [SerializeField] private Button _nextButton;
        
        [Space]
        
        [SerializeField] private TextMeshProUGUI _moneyText;
        [SerializeField] private TextMeshProUGUI _goldText;

        [Inject] private RunTimeDataFeature _runTimeDataFeature;
        
        protected override void OnWindowOpen()
        {
            base.OnWindowOpen();
            UpdateTexts();
        }

        private void Init()
        {
            
        }
        
        private void UpdateTexts()
        {
            _moneyText.text = _runTimeDataFeature.RunTimeData.InGameDollarusAmount.ToString();
            _goldText.text = _runTimeDataFeature.RunTimeData.InGameGoldAmount.ToString();
        }

        private void StartAnimations()
        {
            
        }
    }
}