using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Customer.Ai
{
    public class CustomerAiAction : Action
    {
        public Customer Customer;

        public override void OnAwake()
        {
            base.OnAwake();
            Customer = GetComponent<Customer>();
        }
    }
}