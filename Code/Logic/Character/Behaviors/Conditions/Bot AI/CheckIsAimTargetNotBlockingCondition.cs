using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Conditions.Bot_AI
{
    public class CheckIsAimTargetNotBlockingCondition : CharacterCondition
    {
        public override TaskStatus OnUpdate()
        {
            Transform muzzleT = BotCharacterRef.AiAttack.CurrentWeapon.GetAttachmentManager().GetEquippedMuzzle().GetSocket();
            Vector3 dir = BotCharacterRef.AimTarget.position - muzzleT.position;
            
            RaycastHit hit;
            // Debug.DrawRay(muzzleT.position, dir * 50f, Color.red);
            if (Physics.Raycast(muzzleT.position, dir, out hit, 50, BotCharacterRef.AiAttack.AttackTargetLayerMask))
            {
                if (hit.collider.gameObject != BotCharacterRef.PlayerTarget.gameObject) return TaskStatus.Failure;
                
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }
}