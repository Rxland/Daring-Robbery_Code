using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _GAME.Code.UI.Shop
{
    public class AttachmentUiButtonRef : MonoBehaviour
    {
        public Button Button;
        public CanvasGroup CanvasGroup;

        public void Show()
        {
            transform.transform.localScale = Vector3.zero;
            gameObject.SetActive(true);

            DOTween.Sequence()
                .Append(transform.DOScale(1f, 0.2f))
                .Join(CanvasGroup.DOFade(1f, 0.2f));
        } 
        
        public void Hide()
        {
            DOTween.Sequence()
                .Append(transform.DOScale(1.2f, 0.2f))
                .Join(CanvasGroup.DOFade(0f, 0.2f))
                .AppendCallback(() => gameObject.SetActive(false));
        }
    }
}