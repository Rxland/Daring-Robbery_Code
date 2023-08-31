using BehaviorDesigner.Runtime.Tasks;

namespace _GAME.Code.Logic.Character.Behaviors.Conditions
{
    public class CheckIfPlayerReachedDestination : CharacterCondition
    {
        public override TaskStatus OnUpdate()
        {
            if (BotCharacterRef.AIPath.reachedDestination || !BotCharacterRef.AIPath.hasPath) return TaskStatus.Success;

            return TaskStatus.Failure;
        }
    }
}