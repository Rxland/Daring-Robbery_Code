using _GAME.Code.UI.Windows;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _GAME.Code.UI.Shop
{
    public class WeaponRotateZone : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private ShopWindow _shopWindow;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _rotationXClamp;
        [SerializeField] private float _rotationYClamp;

        private bool _isDraging = false;
        private Vector3 _lastMovePos;
        
        private void Update()
        {
            if (!_isDraging || !_shopWindow.SpawnedWeapon)
            {
                _lastMovePos = Input.mousePosition;
                return;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 moveDelta = _lastMovePos - Input.mousePosition;

                _shopWindow.SpawnedWeapon.transform.localEulerAngles += new Vector3(0f, moveDelta.x, -moveDelta.y) * _rotationSpeed;
            }
            
            _lastMovePos = Input.mousePosition;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isDraging = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isDraging = false;
        }
    }
}