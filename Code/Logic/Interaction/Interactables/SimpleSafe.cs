using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _GAME.Code.Logic.Interaction.Interactables
{
    public class SimpleSafe : Interactable
    {
        [SerializeField] private Transform _door;
        [SerializeField] private Transform _doorHandle;
        [SerializeField] private float _openAngle;
        [SerializeField] private float _openTime;
        [SerializeField] private float _rotationHandleTime;
        [SerializeField] private float _rotationHandleValue;
        [SerializeField] private Ease _openEase;
        [SerializeField] private Ease _rotationHandleEase;
        [SerializeField] private AudioSource _openSound;
        [Space] 
        
        [SerializeField] private List<Transform> _lootSpawnPoints;

        protected override void Start()
        {
            base.Start();
            GameFactory.SpawnLootInPoints(_lootSpawnPoints);
        }

        public override void Interact(Transform whoInteractT) { }

        public override void Interact()
        {
            OpenDoorAnimation();
        }
        
        private void OpenDoorAnimation()
        {
            DOTween.Sequence()
                .Append(_doorHandle.DOLocalRotate(new Vector3(_rotationHandleValue, 0f, 0f), _rotationHandleTime, RotateMode.FastBeyond360).SetEase(_rotationHandleEase))
                .Append(_door.DOLocalRotate(new Vector3(0f, 0f, _openAngle), _openTime).SetEase(_openEase))
                .AppendCallback(() =>
                {
                    gameObject.layer = StaticDataService.LayerMasksStaticData.IngnoreRaycastMask;
                });
        }
    }
}