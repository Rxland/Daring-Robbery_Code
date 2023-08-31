using System.Collections.Generic;
using _GAME.Code.Logic.Interaction.Interactables;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME.Code.Logic.Interaction.Safe_Deposit_Box
{
    public class SafeDepositLootBox : Interactable
    {
        [SerializeField] public List<Transform> SpawnLootPoints;
        [ReadOnly] public List<Treasure> TreasuresInsideTheBox;
        [Space]
        
        [SerializeField] private Transform _moveBoxTransform;
        [SerializeField] private Transform _secondaryBoxCapTransform;
        [SerializeField] private Transform _baseBoxCapTransform;

        [Header("Animation Settings")] 
        [SerializeField] private float _ZOpenPos;
        [SerializeField] private Vector3 _secondaryBoxEndRotation;
        [SerializeField] private Vector3 _baseBoxEndRotation;

        [Header("Sounds")] 
        [SerializeField] private AudioSource _CapSound_1;
        [SerializeField] private AudioSource _CapSound_2;
        [SerializeField] private AudioSource _CapSound_3;
        
        public override void Interact(Transform whoInteractT)
        {
            OpenBox();
            CanInteract = false;
        }

        public override void Interact()
        {
            
        }

        private void OpenBox()
        {
            SpriteIteractIndicator.gameObject.SetActive(false);

            DOTween.Sequence()
                .AppendCallback(() => _CapSound_1.Play())
                .Append(_secondaryBoxCapTransform.DOLocalRotate(_secondaryBoxEndRotation, 0.5f).SetEase(Ease.Linear))
                .AppendCallback(() => _CapSound_2.Play())
                .Append(_moveBoxTransform.DOLocalMoveZ(_moveBoxTransform.localPosition.z + _ZOpenPos, 0.5f).SetEase(Ease.Linear))
                .AppendCallback(() => _CapSound_3.Play())
                .Append(_baseBoxCapTransform.DOLocalRotate(_baseBoxEndRotation, 0.3f).SetEase(Ease.Linear))
                .AppendCallback(() => SetInteractTreasuresInsideTheBox());
        }
        private void CloseBox()
        {
            DOTween.Sequence()
                .AppendCallback(() => _CapSound_3.Play())
                .Append(_baseBoxCapTransform.DOLocalRotate(Vector3.zero, 0.3f).SetEase(Ease.Linear))
                .AppendCallback(() => _CapSound_2.Play())
                .Append(_moveBoxTransform.DOLocalMoveZ(_moveBoxTransform.localPosition.z - _ZOpenPos, 0.5f).SetEase(Ease.Linear))
                .AppendCallback(() => _CapSound_1.Play())
                .Append(_secondaryBoxCapTransform.DOLocalRotate(Vector3.zero, 0.5f).SetEase(Ease.Linear));
        }

        public void DeleteTreasuresInsideTheBox(Treasure treasure)
        {
            TreasuresInsideTheBox.Remove(treasure);

            if (TreasuresInsideTheBox.Count == 0)
                CloseBox();
        }

        private void SetInteractTreasuresInsideTheBox()
        {
            foreach (Treasure treasure in TreasuresInsideTheBox)
            {
                treasure.CanInteract = true;
                treasure.IsNeedCheckView = false;
                treasure.UiIndicationOffset = Vector3.zero;
            } 
        }
    }
}