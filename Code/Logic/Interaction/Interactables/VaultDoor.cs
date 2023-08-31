using DG.Tweening;
using UnityEngine;

namespace _GAME.Code.Logic.Interaction.Interactables
{
    public class VaultDoor : Interactable
    {
        [SerializeField] private Transform _door;
        [SerializeField] private Transform _smallRotationHandle;
        [SerializeField] private Transform _mainRotationHandle;
        [SerializeField] private float _openAngle;
        [SerializeField] private float _openTime;
        [SerializeField] private float _rotationHandleTime;
        [SerializeField] private float _rotationHandleValue;
        [SerializeField] private Ease _openEase;
        [SerializeField] private Ease _rotationHandleEase;
        [SerializeField] private AudioSource _openSound;
        
        public override void Interact(Transform whoInteractT) { }

        public override void Interact()
        {
            OpenDoorAnimation();
        }

        private void OpenDoorAnimation()
        {
            DOTween.Sequence()
                .Append(_smallRotationHandle.DORotate(new Vector3(0f, 0f, _rotationHandleValue), _rotationHandleTime, RotateMode.FastBeyond360).SetEase(_rotationHandleEase))
                .Append(_mainRotationHandle.DORotate(new Vector3(0f, 0f, _rotationHandleValue), _rotationHandleTime, RotateMode.FastBeyond360).SetEase(_rotationHandleEase))
                // .AppendCallback(() => _openSound.Play())
                .Append(_door.DORotate(new Vector3(0f, _openAngle, 0f), _openTime).SetEase(_openEase));
        }
    }
}