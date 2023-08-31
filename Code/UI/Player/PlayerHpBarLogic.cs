using System;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Logic.Character.Ref;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _GAME.Code.UI.Player
{
    public class PlayerHpBarLogic : MonoBehaviour
    {
        [SerializeField] private Image _mainHpBarImg;
        [SerializeField] private Image _secondHpBarImg;
        [SerializeField] private TextMeshProUGUI _hpPercentAmountText;

        private GameFactory _gameFactory;

        [Header("Auto Heal Time Settings")]

        [SerializeField] private float _autoHealStartDelay;
        private float _autoHealStartDelayFireTime;

        [Header("Heal")]
        [SerializeField] private float _healPerTick;
        [SerializeField] private float _healTickTime;
        private float _healTickFireTime;

        private HudUiRef _hudUiRef;
        
        [Inject]
        private void Constructor(GameFactory gameFactory, HudUiRef hudUiRef)
        {
            _gameFactory = gameFactory;
            _hudUiRef = hudUiRef;
        }
        
        private void Awake()
        {
            _secondHpBarImg.DOFade(0f, 0f);
        }

        private void Update()
        {
            if (!_gameFactory.Player) return;
            
            AutoHeal();
        }

        public void TakeDamageAction()
        {
            _autoHealStartDelayFireTime = _autoHealStartDelay;
            
            UpdateHpUi();
        }
        
        private void UpdateHpUi()
        {
            if (!_gameFactory.Player) return;
            
            float currentPlayerHp = _gameFactory.Player.Stats.CurrentHp;
            float maxPlayerHp = _gameFactory.Player.Stats.MaxHp;
            float hpPercentage = (currentPlayerHp / maxPlayerHp) * 100f;
            
            _mainHpBarImg.DOFillAmount( currentPlayerHp / maxPlayerHp, 0.2f);
            _secondHpBarImg.DOFade(  1f - (currentPlayerHp / maxPlayerHp), 0.2f);
            _hudUiRef.FullScreenHpBloodImg.DOFade(  1f - (currentPlayerHp / maxPlayerHp), 0.2f);
            _hpPercentAmountText.text = $"{hpPercentage}%";
        }

        private void AutoHeal()
        {
            if (_gameFactory.Player.Stats.CurrentHp >= _gameFactory.Player.Stats.MaxHp) return;

            if (_autoHealStartDelayFireTime > 0)
            {
                _autoHealStartDelayFireTime -= Time.deltaTime;
                _healTickFireTime = _healTickTime;
                return;
            }

            if (_healTickFireTime > 0)
            {
                _healTickFireTime -= Time.deltaTime;
                return;
            }
            _healTickFireTime = _healTickTime;
            
            _gameFactory.Player.Stats.CurrentHp = Mathf.Clamp(_gameFactory.Player.Stats.CurrentHp + _healPerTick, 0, _gameFactory.Player.Stats.MaxHp);

            UpdateHpUi();
        }
    }
}