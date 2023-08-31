using System.Collections.Generic;
using _GAME.Code.Infrastructure.Services;
using UnityEngine;

namespace _GAME.Code.UI.Canvases
{
    public class CanvasesController : MonoBehaviour, IService
    {
        public List<CanvasBase> AllCanvases;

        public CanvasBase CurrentCanvas;
        
        public void OpenCanvas(CanvasType canvasType)
        {
            foreach (CanvasBase canvas in AllCanvases)
            {
                if (canvas.CanvasType == canvasType)
                {
                    CurrentCanvas = canvas;
                    CurrentCanvas.ShowCanvas();
                }
                else
                {
                    canvas.HideCanvas();
                }
            }
        }

        public CanvasBase GetCanvas(CanvasType canvasType)
        {
            foreach (CanvasBase canvas in AllCanvases)
            {
                if (canvas.CanvasType == canvasType)
                {
                    return canvas;
                }
            }
            return null;
        } 
    }
}