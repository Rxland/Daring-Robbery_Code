using _GAME.Code.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Camera_Logic
{
    public class CameraLogic : MonoBehaviour
    {
        public Canvas MenuCanvas;
        public Canvas GameCanvas;
        public Camera CameraMenu;

        [Inject] private GameFactory _gameFactory;

        
        public void SetActiveGameCanvas()
        {
            MenuCanvas.gameObject.SetActive(false);
            GameCanvas.gameObject.SetActive(true);
        }
        
        
    }
}