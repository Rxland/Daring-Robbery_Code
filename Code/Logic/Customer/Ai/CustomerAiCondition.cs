using BehaviorDesigner.Runtime.Tasks;

namespace _GAME.Code.Logic.Customer.Ai
{
    public class CustomerAiCondition : Conditional
    {
        public Customer Customer;

        public override void OnAwake()
        {
            base.OnAwake();
            Customer = GetComponent<Customer>();
        }
    }
}