using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Conditions.Bot_AI
{
    public class CheckCanStartStrafeCondition : CharacterCondition
    {
        public override TaskStatus OnUpdate()
        {
            float distBtwBotAndAimTarget = Vector3.Distance(BotCharacterRef.PlayerTarget.position, transform.position);

            if (!BotCharacterRef.IsStrafing && distBtwBotAndAimTarget < BotCharacterRef.StartStrafeDist)
            {
                BotCharacterRef.IsStrafing = true;
                return TaskStatus.Success;
            }
            
            return TaskStatus.Failure;
        }
    }
}