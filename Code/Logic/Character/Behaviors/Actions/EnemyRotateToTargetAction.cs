using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Actions
{
    public class EnemyRotateToTargetAction : CharacterAction
    {
        public override void OnStart()
        {
            float singleStep = BotCharacterRef.Stats.RotateToSpeed * Time.deltaTime;
            Vector3 targetDirection = BotCharacterRef.PlayerTarget.position - transform.position;
            
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            newDirection.y = 0f;
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}