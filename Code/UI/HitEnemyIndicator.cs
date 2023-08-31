using UnityEngine;
using UnityEngine.UI;

namespace _GAME.Code.UI
{
    public class HitEnemyIndicator : MonoBehaviour
    {
        [SerializeField] private Color _killedColor;
        [SerializeField] private Image _indicatorImage;
        private Camera _playerCamera;
        private Vector3 _hitPos;

        private bool _isInitDone;
        
        public void Init(Camera playerCamera, Vector3 hitPos)
        {
            _playerCamera = playerCamera;
            _hitPos = hitPos;
            
            _isInitDone = true;
        }

        private void Update()
        {
            if (!_isInitDone) return;
            
            Vector3 screenPos = _playerCamera.WorldToScreenPoint(_hitPos);
            Vector3 hitImgPos = screenPos;
            hitImgPos.z = 0f;

            transform.position = hitImgPos;
        }

        public void SetIndicatorColorToKilled()
        {
            _indicatorImage.color = _killedColor;
        }
    }
}