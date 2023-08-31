using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Actions.Bot_AI
{
    public class SetRandomStrafePoint : CharacterAction
    {
        public override TaskStatus OnUpdate()
        {
            Vector3 randomStrafePoint = new Vector3(
                transform.position.x + GetRandomPointInRangeUnity().x,
                BotCharacterRef.transform.position.y,
                transform.position.z + GetRandomPointInRangeUnity().y);
            
            float distBtwStrafePointAndAttackRange = Vector3.Distance(BotCharacterRef.PlayerTarget.transform.position, randomStrafePoint);

            if (distBtwStrafePointAndAttackRange >= BotCharacterRef.MaxRandomStrafePointRange)
                return TaskStatus.Running;

            BotCharacterRef.MoveToTarget.transform.position = randomStrafePoint;
            
            return TaskStatus.Success;
        }

        Vector2 GetRandomPointInRangeUnity()
        {
            float randomX = Random.Range(-BotCharacterRef.MinRandomStrafePointRange, BotCharacterRef.MinRandomStrafePointRange);
            float randomY = Random.Range(-BotCharacterRef.MinRandomStrafePointRange, BotCharacterRef.MinRandomStrafePointRange);
        
            return new Vector2(randomX, randomY);
        }
    }
}