using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Conditions.Bot_AI
{
    public class CheckCanMoveToTargetCondition : CharacterCondition
    {
        public override TaskStatus OnUpdate()
        {
            if (!BotCharacterRef.CanMove)
            {
                SetFailureActions();
                return TaskStatus.Failure;
            }
            
            float distBtwAimTarget = Vector3.Distance(transform.position, BotCharacterRef.MoveToTarget.position);

            if (distBtwAimTarget < BotCharacterRef.ReachedMoveToTargetRange)
            {
                SetFailureActions();
                
                return TaskStatus.Failure;
            }
            
            return TaskStatus.Success;
        }

        private void SetFailureActions()
        {
            BotCharacterRef.IsStrafing = false;
            BotCharacterRef.AIPath.isStopped = true;
            BotCharacterRef.CharacterAnimator.SetStrafeActive(false);
        }
    }
}