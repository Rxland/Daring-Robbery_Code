using _GAME.Code.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Features
{
    public class InteractionUiFeature : IService
    {
        private GameObject _interactUiObject;
        
        [Inject] private StaticDataService _staticDataService;
        
        public void Init()
        {
            _interactUiObject = GameObject.Instantiate(_staticDataService.InteractionUiStaticData.InteractUiWayPointPrefab);
            HideInteractUiObject();
        }
        
        public void ShowInteractUiObject(Vector3 pos, float yOffset)
        {
            if(!_interactUiObject) return;
            
            Vector3 newPos = pos;
            newPos.y += yOffset;
            
            _interactUiObject.transform.position = newPos;
            _interactUiObject.gameObject.SetActive(true);
        }
        
        public void HideInteractUiObject()
        {
            if(!_interactUiObject) return;
            
            _interactUiObject.gameObject.SetActive(false);
        }
    }
}