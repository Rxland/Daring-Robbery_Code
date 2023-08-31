using BehaviorDesigner.Runtime.Tasks;

namespace _GAME.Code.Logic.Character.Behaviors.Conditions.Bot_AI
{
    public class CheckHaveAimTargetCondition : CharacterCondition
    {
        public override TaskStatus OnUpdate()
        {
            if (!BotCharacterRef.CanAim || !BotCharacterRef.AimTarget.gameObject.activeSelf)
            {
                return TaskStatus.Failure;
            }

            return TaskStatus.Success;
        }
    }
}