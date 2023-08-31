using UnityEngine;

namespace _GAME.Code.Logic.Customer
{
    public class CustomerAnimator : MonoBehaviour
    {
        public Animator Animator;

        private const string _run = "Run";

        public void SetAnimToRun()
        {
            Animator.SetBool(_run, true);
        }
    }
}