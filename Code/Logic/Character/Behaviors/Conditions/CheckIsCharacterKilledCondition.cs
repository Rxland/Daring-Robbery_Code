using BehaviorDesigner.Runtime.Tasks;

namespace _GAME.Code.Logic.Character.Behaviors.Conditions
{
    public class CheckIsCharacterKilledCondition : CharacterCondition
    {
        public override TaskStatus OnUpdate()
        {
            if (BotCharacterRef.Stats.IsKilled)
                return TaskStatus.Success;

            return TaskStatus.Failure;
        }
    }
}