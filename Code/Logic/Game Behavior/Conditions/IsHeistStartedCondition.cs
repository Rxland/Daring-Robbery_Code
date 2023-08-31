using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Game_Behavior.Conditions
{
    public class IsHeistStartedCondition : GameBehaviorCondition
    {
        public override TaskStatus OnUpdate()
        {
            if (GameBehavior.IsHeistStarted)
                return TaskStatus.Success;

            return TaskStatus.Failure;
        }
    }
}