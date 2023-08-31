using UnityEngine;

namespace _GAME.Code.Logic.Customer.Ai.Actions
{
    public class CustomerStartAction : CustomerAiAction
    {
        public override void OnStart()
        {
            Customer.CustomerAnimator.Animator.runtimeAnimatorController =
                Customer.StaticDataService.CustomersMainStaticData.AnimatorControllersForRandomReplace[Random.Range(0,
                    Customer.StaticDataService.CustomersMainStaticData.AnimatorControllersForRandomReplace.Count)];
        }
    }
}