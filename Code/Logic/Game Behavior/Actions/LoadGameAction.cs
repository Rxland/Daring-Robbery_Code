using _GAME.Code.UI.Canvases;

namespace _GAME.Code.Logic.Game_Behavior.Actions
{
    public class LoadGameAction : GameBehaviorAction
    {
        public override void OnStart()
        {
            Load();
        }
        
        private void Load()
        {
            GameBehavior.SaveFeature.Load();
            GameBehavior.SettingsFeature.InitGameSettings();
            GameBehavior.UiFeature.Init();
            GameBehavior.CanvasesController.OpenCanvas(CanvasType.LoadingCanvas);
            GameBehavior.IsGameLoaded = true;
        }
    }
}