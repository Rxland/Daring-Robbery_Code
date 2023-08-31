using DG.Tweening;
using UnityEngine.UI;

namespace _GAME.Code.UI.Canvases
{
    public class GameCanvas : CanvasBase
    {
        public Image StartFadeImg;

        public override void ShowCanvas()
        {
            base.ShowCanvas();
            
            StartFadeImg.gameObject.SetActive(true);
            StartFadeImg.DOFade(0f, 5);
        }
    }
}