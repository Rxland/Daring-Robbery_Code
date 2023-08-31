using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Actions.Bot_AI
{
    public class AimToTargetAction : CharacterAction
    {
        public override TaskStatus OnUpdate()
        {
            Vector3 aimPos = BotCharacterRef.PlayerTarget.position;
            aimPos.y += 1.5f;
            
            BotCharacterRef.AimTarget.transform.position = aimPos;
            
            RotateMainBodyToTargetByAimAngle();
            CalculateStrafeDirection();
            
            return TaskStatus.Success;
        }

        private void RotateMainBodyToTargetByAimAngle()
        {
            Vector3 aimTargetDirection = BotCharacterRef.AimTarget.position - transform.position;
            
            if (BotCharacterRef.EnemyIkController.IsOutOffAngle)
            {
                float singleStep = BotCharacterRef.Stats.RotateToSpeed * Time.deltaTime;
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, aimTargetDirection, singleStep, 0.0f);
                
                newDirection.y = 0f;
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        } 

        private void CalculateStrafeDirection()
        {
            Vector3 moveTargetDirection = (BotCharacterRef.MoveToTarget.position - transform.position).normalized;
            Vector3 localMoveDirection = transform.InverseTransformDirection(moveTargetDirection);

            float xDirection = localMoveDirection.x;
            float yDirection = localMoveDirection.z;
            
            // Debug.Log("localMoveDirection " + localMoveDirection);
            
            BotCharacterRef.CharacterAnimator.SetStrafeX(Mathf.Lerp(BotCharacterRef.CharacterAnimator.GetStrafeX(), 
                xDirection, BotCharacterRef.CharacterAnimator.StrafeAnimationLerpValue * Time.deltaTime));
            BotCharacterRef.CharacterAnimator.SetStrafeY(Mathf.Lerp(BotCharacterRef.CharacterAnimator.GetStrafeY(), 
                yDirection, BotCharacterRef.CharacterAnimator.StrafeAnimationLerpValue * Time.deltaTime));
        }
    }
}