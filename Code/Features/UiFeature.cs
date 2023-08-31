using _GAME.Code.UI.Canvases;
using _GAME.Code.UI.Windows.Invenotory;
using UnityEngine;

namespace _GAME.Code.Features
{
    public class UiFeature : MonoBehaviour
    {
        public MainMenuCanvas MainMenuCanvas;
        public InventoryWindow InventoryWindow;

        public void Init()
        {
            MainMenuCanvas.PlayerProgressUi.Init();
        }
    }
}