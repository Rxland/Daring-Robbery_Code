using _GAME.Code.Logic.Game_Behavior;
using UnityEngine.UI;
using Zenject;

namespace _GAME.Code.UI.Windows
{
    public class MainMenuWindow : WindowBase
    {
        public Button StartLevelButotn;

        [Inject] private GameBehavior _gameBehavior;


        public void Init()
        {
            InitButtons();
        }
        
        private void InitButtons()
        {
            StartLevelButotn.onClick.AddListener(() =>
            {
                _gameBehavior.IsLevelStartLoading = true;
            });
        }
    }
}