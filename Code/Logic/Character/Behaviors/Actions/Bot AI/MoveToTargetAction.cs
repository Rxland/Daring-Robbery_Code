
namespace _GAME.Code.Logic.Character.Behaviors.Actions.Bot_AI
{
    public class MoveToTargetAction : CharacterAction
    {
        public override void OnStart()
        {
            base.OnStart();
            
            BotCharacterRef.AIPath.isStopped = false;
            BotCharacterRef.AIPath.destination = BotCharacterRef.MoveToTarget.position;
            BotCharacterRef.CharacterAnimator.SetStrafeActive(true);
        }
    }
}