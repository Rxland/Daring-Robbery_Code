using System.Collections.Generic;
using _GAME.Code.UI.Top_Navigation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME.Code.UI.Windows
{
    public class MainMenuWindowsController : MonoBehaviour
    {
        public List<WindowBase> AllWindows;
        [ReadOnly] public WindowsType CurrentWindowType;
        
        public void OpenWindow(TopNavigationButton topNavigationButton)
        {
            if (topNavigationButton.WindowsType == CurrentWindowType) return;
            
            foreach (WindowBase window in AllWindows)
            {
                if (topNavigationButton.WindowsType == window.WindowsType)
                {
                    CurrentWindowType = window.WindowsType;
                    window.SetActiveWindow(true);
                }
            }
        }
        
        public void OpenWindowByWindowType(WindowsType windowType)
        {
            if (windowType == CurrentWindowType) return;
            
            foreach (WindowBase window in AllWindows)
            {
                if (windowType == window.WindowsType)
                {
                    CurrentWindowType = window.WindowsType;
                    window.SetActiveWindow(true);
                }
            }
        }
    }
}