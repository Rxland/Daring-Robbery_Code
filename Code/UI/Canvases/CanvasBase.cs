using UnityEngine;

namespace _GAME.Code.UI.Canvases
{
    public class CanvasBase : MonoBehaviour
    {
        public CanvasType CanvasType;

        public virtual void ShowCanvas()
        {
            gameObject.SetActive(true);
        }
        
        public virtual void HideCanvas()
        {
            gameObject.SetActive(false);
        }
    }
}