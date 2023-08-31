using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Customer.Ai.Conditions
{
    public class IsCustomerReachedRunPointCondition : CustomerAiCondition
    {
        public override TaskStatus OnUpdate()
        {
            if (Customer.AIPath.reachedDestination)
                return TaskStatus.Success;

            return TaskStatus.Failure;
        }
    }
}