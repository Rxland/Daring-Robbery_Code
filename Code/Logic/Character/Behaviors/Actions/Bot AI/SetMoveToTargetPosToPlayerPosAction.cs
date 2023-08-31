using BehaviorDesigner.Runtime.Tasks;

namespace _GAME.Code.Logic.Character.Behaviors.Actions.Bot_AI
{
    public class SetMoveToTargetPosToPlayerPosAction : CharacterAction
    {
        public override void OnStart()
        {
            base.OnStart();
            BotCharacterRef.MoveToTarget.position = BotCharacterRef.PlayerTarget.position;
        }
    }
}