using _GAME.Code.UI.Top_Navigation;
using _GAME.Code.UI.Windows;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Interaction.Interactables
{
    public class ExitHeistInteractor : Interactable
    {
        [Inject] private MainMenuWindowsController _mainMenuWindowsController;
        
        public override void Interact(Transform whoInteractT)
        {
            _mainMenuWindowsController.OpenWindowByWindowType(WindowsType.Won);
        }
    }
}