using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Conditions.Bot_AI
{
    public class CheckIfTargetPlayerOnRange : CharacterCondition
    {
        public override TaskStatus OnUpdate()
        {
            float distBtwBotAndPlayerTarget = Vector3.Distance(BotCharacterRef.PlayerTarget.position, transform.position);

            if (distBtwBotAndPlayerTarget <= BotCharacterRef.AiAttack.AttackRange)
            {
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }
}