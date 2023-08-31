using UnityEngine;

namespace _GAME.Code.Logic.Customer.Ai.Actions
{
    public class CustomerRunAction : CustomerAiAction
    {
        public override void OnStart()
        {
            Customer.AIPath.destination = GetRandomPointToRun().position;
            Customer.CustomerAnimator.SetAnimToRun();
        }

        private Transform GetRandomPointToRun()
        {
            return Customer.EnvFactory.Level.CustomersRunToPointsList[
                Random.Range(0, Customer.EnvFactory.Level.CustomersRunToPointsList.Count)];
        }
    }
}