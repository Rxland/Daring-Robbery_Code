using BehaviorDesigner.Runtime.Tasks;

namespace _GAME.Code.Logic.Game_Behavior.Conditions
{
    public class IsLevelStartLoadingCondition : GameBehaviorCondition
    {
        public override TaskStatus OnUpdate()
        {
            if (GameBehavior.IsLevelStartLoading)
                return TaskStatus.Success;

            return TaskStatus.Failure;
        }
    }
}