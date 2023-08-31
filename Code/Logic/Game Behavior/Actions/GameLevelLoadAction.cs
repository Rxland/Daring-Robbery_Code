using System.Collections.Generic;
using _GAME.Code.Logic.Env.Enemies;
using _GAME.Code.UI.Canvases;

namespace _GAME.Code.Logic.Game_Behavior.Actions
{
    public class GameLevelLoadAction : GameBehaviorAction
    {
        private List<EnemyWaveSpawner> _enemySpawners;

        public override void OnStart()
        {
            GameBehavior.EnvFactory.LevelLoadedAction += Load;

            StartCoroutine(GameBehavior.EnvFactory.SpawnLevel(1));
        }

        
        private void Load()
        {
            GameBehavior.RunTimeDataFeature.Init();
            
            AstarPath.active.Scan();
            
            GameBehavior.GameFactory.SpawnPlayer(GameBehavior.EnvFactory.Level.PlayerSpawnPoint);
            
            GameBehavior.interactionUiFeature.Init();
            GameBehavior.HudUiFeature.Init();
            GameBehavior.CameraLogic.SetActiveGameCanvas();
            GameBehavior.EnemyFactory.SpawnStaticEnemies();
            
            GameBehavior.CanvasesController.OpenCanvas(CanvasType.GameCanvas);
        }
    }
}