using _GAME.Code.UI.Top_Navigation;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _GAME.Code.UI.Windows
{
    public class WindowBase : MonoBehaviour
    {
        public WindowsType WindowsType;
        public Button BackButton;

        [Inject] [HideInInspector] public MainMenuWindowsController MainMenuWindowsController;
        
        protected virtual void Awake()
        {
            BackButton.onClick.RemoveAllListeners();
            BackButton.onClick.AddListener(() => SetActiveWindow(false));
        }

        public void SetActiveWindow(bool activeMode)
        {
            if (activeMode)
                OnWindowOpen();
            else 
                MainMenuWindowsController.CurrentWindowType = WindowsType.None;
            
            gameObject.SetActive(activeMode);
        }

        protected virtual void OnWindowOpen()
        {
            
        }
    }
}