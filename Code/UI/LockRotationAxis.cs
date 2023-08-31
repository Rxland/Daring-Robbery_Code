using UnityEngine;

namespace _GAME.Code.UI
{
    public class LockRotationAxis : MonoBehaviour
    {
        [SerializeField] private bool _lockX;
        [SerializeField] private bool _lockY;
        [SerializeField] private bool _lockZ;
        
        private void Update()
        {
            float _xRotation = transform.eulerAngles.x;
            float _yRotation = transform.eulerAngles.y;
            float _zRotation = transform.eulerAngles.z;

            if (_lockX) _xRotation = 0f;
            if (_lockY) _yRotation = 0f;
            if (_lockZ) _zRotation = 0f;

            transform.eulerAngles = new Vector3(_xRotation, _yRotation, _zRotation);
        }
    }
}