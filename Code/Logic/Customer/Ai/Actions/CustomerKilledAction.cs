using UnityEngine;

namespace _GAME.Code.Logic.Customer.Ai.Actions
{
    public class CustomerKilledAction : CustomerAiAction
    {
        public override void OnStart()
        {
            Customer.AIPath.enabled = false;
            Customer.Seeker.enabled = false;
        }
    }
}