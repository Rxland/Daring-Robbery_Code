using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Customer.Ai.Conditions
{
    public class IsCustomerKilledCondition : CustomerAiCondition
    {
        public override TaskStatus OnUpdate()
        {
            if (Customer.Stats.IsKilled)
                return TaskStatus.Success;

            return TaskStatus.Failure;
        }
    }
}