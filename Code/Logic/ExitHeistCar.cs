using _GAME.Code.Features;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Logic.Interaction.Interactables;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic
{
    public class ExitHeistCar : MonoBehaviour
    {
        [SerializeField] private Waypoint_Indicator _exitHeistIndicator;
        [SerializeField] private ExitHeistInteractor _exitHeistInteractor;

        [Header("Animation")] 
        [SerializeField] private DOTweenPath _carDOTweenPath;

        [Header("Sounds")] 
        [SerializeField] private AudioSource _carMoveEngineSound;
        [SerializeField] private AudioSource _carStayEngineSound;
        
        [Inject] private RunTimeDataFeature _runTimeDataFeature;
        [Inject] private StaticDataService _staticDataService;

        private bool _isCarActivated;
        
        public void UpdateActiveExitHeistIndicator()
        {
            if (!_isCarActivated && _runTimeDataFeature.RunTimeData.InGameDollarusAmount >= _staticDataService.HeistStaticData.DollarusAmountToCanEndHeist)
            {
                _isCarActivated = true;
                _carDOTweenPath.DOPlay();
                _carMoveEngineSound.Play();
            }
        }

        public void CarOnPlace()
        {
            _exitHeistInteractor.gameObject.SetActive(true);
            _exitHeistIndicator.gameObject.SetActive(true);
            
            _carMoveEngineSound.Stop();
            _carStayEngineSound.Play();
        }
    }
}