using BehaviorDesigner.Runtime.Tasks;

namespace _GAME.Code.Logic.Character.Behaviors.Conditions.Bot_AI
{
    public class CheckIsStrafingCondition : CharacterCondition
    {
        public override TaskStatus OnUpdate()
        {
            if (BotCharacterRef.IsStrafing)
                return TaskStatus.Success;

            return TaskStatus.Failure;
        }
    }
}