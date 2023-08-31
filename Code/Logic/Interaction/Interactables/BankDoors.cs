using DG.Tweening;
using UnityEngine;

namespace _GAME.Code.Logic.Interaction.Interactables
{
    public class BankDoors : Interactable
    {
        [SerializeField] private Transform _leftDoor;
        [SerializeField] private Transform _rightDoor;
        [Space]
        
        [SerializeField] private float _rotationAngle;
        [SerializeField] private float _rotationDuraction;
        [SerializeField] private Ease _rotationEase;
        
        public override void Interact(Transform whoInteractT)
        {
            if (!CanInteract) return;
            CanInteract = false;

            GameBehavior.IsHeistStarted = true;
            
            OpenDoors();
        }
        
        private void OpenDoors()
        {
            _leftDoor.DOLocalRotate(
                new Vector3(_leftDoor.localEulerAngles.x, -_rotationAngle, _leftDoor.localEulerAngles.z),
                _rotationDuraction).SetEase(_rotationEase);
            _rightDoor.DOLocalRotate(
                new Vector3(_leftDoor.localEulerAngles.x, _rotationAngle, _leftDoor.localEulerAngles.z),
                _rotationDuraction).SetEase(_rotationEase);
        }
    }
}