using _GAME.Code.UI.Canvases;
using BehaviorDesigner.Runtime.Tasks;

namespace _GAME.Code.Logic.Game_Behavior.Actions
{
    public class GameMenuLoadAction : GameBehaviorAction
    {
        public override TaskStatus OnUpdate()
        {
            Load();
            
            return TaskStatus.Success;
        }
        
        private void Load()
        {
            GameBehavior.CanvasesController.OpenCanvas(CanvasType.MainMenuCanvas);
            GameBehavior.TopNavigation.UpdateCurrentMoneyAmount();
            GameBehavior.MainMenuWindow.Init();
        }
    }
}