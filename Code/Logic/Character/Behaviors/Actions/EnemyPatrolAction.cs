using BehaviorDesigner.Runtime.Tasks;

namespace _GAME.Code.Logic.Character.Behaviors.Actions
{
    public class EnemyPatrolAction : CharacterAction
    {
        public override void OnStart()
        {
            BotCharacterRef.CharacterAnimator.SetActiveMoveAnimation(true);
        }

        public override TaskStatus OnUpdate()
        {
            MoveToTarget();

            if (BotCharacterRef.AIPath.reachedDestination)
                return TaskStatus.Success;
            
            return TaskStatus.Running;
        }

        public override void OnEnd()
        {
            if (BotCharacterRef.PatrolPoints.Count > 0)
            {
                BotCharacterRef.PatrolCurrentPointId =
                    (BotCharacterRef.PatrolCurrentPointId + 1) % BotCharacterRef.PatrolPoints.Count;
            }
            BotCharacterRef.CharacterAnimator.SetActiveMoveAnimation(false);
            BotCharacterRef.MoveToTarget = null;
        }

        private void MoveToTarget()
        {
            if (!BotCharacterRef.MoveToTarget && BotCharacterRef.PatrolPoints.Count > 0)
            {
                BotCharacterRef.MoveToTarget = BotCharacterRef.PatrolPoints[BotCharacterRef.PatrolCurrentPointId];
            } 
            
            if (BotCharacterRef.MoveToTarget) 
                BotCharacterRef.AIPath.destination = BotCharacterRef.MoveToTarget.position;
        }
    }
}