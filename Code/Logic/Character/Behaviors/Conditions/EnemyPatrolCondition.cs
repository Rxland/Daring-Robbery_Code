using BehaviorDesigner.Runtime.Tasks;

namespace _GAME.Code.Logic.Character.Behaviors.Conditions
{
    public class EnemyPatrolCondition : CharacterCondition
    {
        public override TaskStatus OnUpdate()
        {
            if (!BotCharacterRef.MoveToTarget && BotCharacterRef.PatrolPoints.Count > 0)
            {
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }
}