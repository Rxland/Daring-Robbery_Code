using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _GAME.Code.UI
{
    public class ParallaxHoverImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _parallaxImg;
        [SerializeField] private float _scale;
        [SerializeField] private float _scaleDuration;
        [SerializeField] private Ease _easeEnter;
        [SerializeField] private Ease _easeExit;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            _parallaxImg.transform.DOScale(Vector3.one * _scale, _scaleDuration).SetEase(_easeEnter);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _parallaxImg.transform.DOScale(Vector3.one, _scaleDuration).SetEase(_easeExit);
        }
    }
}