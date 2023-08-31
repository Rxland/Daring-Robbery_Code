using UnityEngine;

namespace _GAME.Code.UI
{
    public class LookAtCamera : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        
        private void LateUpdate()
        {
            transform.forward = _target ? _target.forward : Camera.main.transform.forward;
        }
    }
}