using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Customer.Ai.Conditions
{
    public class CanCustomerStartRunCondition : CustomerAiCondition
    {
        public override TaskStatus OnUpdate()
        {
            if (Customer.GameBehavior.IsHeistStarted)
                return TaskStatus.Success;

            return TaskStatus.Failure;
        }
    }
}