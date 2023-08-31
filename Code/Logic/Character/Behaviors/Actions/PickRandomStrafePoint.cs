using Pathfinding;
using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Actions
{
    public class PickRandomStrafePoint : CharacterAction
    {
        public float RandomSpread;
        
        public override void OnStart()
        {
            SetRandomDestination();
        }

        private void OnPathConstructed(Path path)
        {
            BotCharacterRef.AIPath.destination = path.vectorPath[path.vectorPath.Count - 1];

            BotCharacterRef.CharacterAnimator.SetStrafeActive(true);
        }
        
        void SetRandomDestination()
        {
            float distBtwPlayer = Vector3.Distance(transform.position, BotCharacterRef.PlayerTarget.position);
            
            Vector3 destination = new Vector3(BotCharacterRef.PlayerTarget.transform.position.x + Random.Range(-RandomSpread, RandomSpread),
            0, transform.position.z + 1f);

            if (distBtwPlayer > BotCharacterRef.AiAttack.AttackMinCloseToTargetRange)
                destination.z = transform.position.z;
            
            BotCharacterRef.Seeker.StartPath(transform.position, destination, OnPathConstructed);
        }
        
        private void OnDrawGizmos()
        {
            if (!BotCharacterRef.AIPath.hasPath) return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(BotCharacterRef.AIPath.steeringTarget, 0.5f);
        }
        
    }
}