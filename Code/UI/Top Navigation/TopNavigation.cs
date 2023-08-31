using System;
using System.Collections.Generic;
using _GAME.Code.Features;
using _GAME.Code.UI.Windows;
using UnityEngine;
using Zenject;

namespace _GAME.Code.UI.Top_Navigation
{
    public class TopNavigation : MonoBehaviour
    {
        [SerializeField] private MoneyAmountContainerRef _currentMoneyAmountContainerRef;
        [SerializeField] private List<TopNavigationButton> _topNavigationButtons;

        [Inject] private SaveFeature _saveFeature;
        [Inject] private MainMenuWindowsController _mainMenuWindowsController;

        private void Awake()
        {
            InitTopNavigationButtons();
        }

        public void UpdateCurrentMoneyAmount()
        {
            _currentMoneyAmountContainerRef.AmountText.text = _saveFeature.SaveData.DollarusAmount.ToString();
        }

        private void InitTopNavigationButtons()
        {
            foreach (TopNavigationButton topNavigationButton in _topNavigationButtons)
            {
                topNavigationButton.Button.onClick.AddListener(() => _mainMenuWindowsController.OpenWindow(topNavigationButton));
            }
        }
        
    }
}