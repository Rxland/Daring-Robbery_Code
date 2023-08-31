using _GAME.Code.Features;
using _GAME.Code.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic
{
    public class Van : MonoBehaviour
    {
        [SerializeField] private Waypoint_Indicator _backBackIndicator;
        [Space]

        [Inject] private RunTimeDataFeature _runTimeDataFeature;
        [Inject] private StaticDataService _staticDataService;
        
        public void UpdateActiveBackBackIndicator()
        {
            // if (_runTimeDataFeature.RunTimeData.TreasureDataList.Count >= _staticDataService.ReturnPlayerStaticData.MaxBackPacks)
            // {
            //     _backBackIndicator.gameObject.SetActive(true);
            // }
            // else
            // {
            //     _backBackIndicator.gameObject.SetActive(false);
            // }
        }
        
    }
}