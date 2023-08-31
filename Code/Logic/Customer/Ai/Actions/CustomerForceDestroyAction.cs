using UnityEngine;

namespace _GAME.Code.Logic.Customer.Ai.Actions
{
    public class CustomerForceDestroyAction : CustomerAiAction
    {
        public override void OnStart()
        {
            GameObject.Destroy(gameObject);
        }
    }
}