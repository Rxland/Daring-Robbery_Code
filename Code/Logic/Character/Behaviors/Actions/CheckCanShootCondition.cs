using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Actions
{
    public class CheckCanShootCondition : CharacterCondition
    {
        public override TaskStatus OnUpdate()
        {
            float dist = Vector3.Distance(transform.position, BotCharacterRef.AimTarget.position);
            
            if (dist <= BotCharacterRef.AiAttack.AttackRange)
                return TaskStatus.Success;
        
            return TaskStatus.Failure;
        }
    }
}