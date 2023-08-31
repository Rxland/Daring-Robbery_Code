using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Game_Behavior.Conditions
{
    public class IsGameLoadedCondition : GameBehaviorCondition
    {
        public override TaskStatus OnUpdate()
        {
            if (GameBehavior.IsGameLoaded)
                return TaskStatus.Success;

            return TaskStatus.Failure;
        }
    }
}