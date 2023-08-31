using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Conditions.Bot_AI
{
    public class CheckIfAimTargetOnAttackRange : CharacterCondition
    {
        public override TaskStatus OnUpdate()
        {
            float distBtwBotAndAimTarget = Vector3.Distance(BotCharacterRef.PlayerTarget.position, transform.position);

            if (distBtwBotAndAimTarget <= BotCharacterRef.AiAttack.AttackRange)
            {
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }
}