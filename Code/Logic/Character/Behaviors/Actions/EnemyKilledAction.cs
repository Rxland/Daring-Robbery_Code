namespace _GAME.Code.Logic.Character.Behaviors.Actions
{
    public class EnemyKilledAction : CharacterAction
    {
        public override void OnStart()
        {
            BotCharacterRef.AIPath.isStopped = true;
            BotCharacterRef.AIPath.enabled = false;
            
            BotCharacterRef.EnemyFactory.RemoveEnemy(BotCharacterRef);
        }
    }
}