using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Actions
{
    public class CheckBodyAngleMoreThenValueCondition : CharacterCondition
    {
        public float MaxAngle;
        public float WeightSmoothTime;
        public float ClampWeight;
        private float velocity;
        
        public override TaskStatus OnUpdate()
        {
            Vector3 direction = BotCharacterRef.PlayerTarget.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle > MaxAngle)
            {
                // Debug.Log("Angle " + angle);

                BotCharacterRef.AimIK.solver.clampWeight = 
                    Mathf.SmoothDamp(BotCharacterRef.AimIK.solver.clampWeight, 1f, ref velocity, WeightSmoothTime * Time.deltaTime);
                
                return TaskStatus.Success;
            }
            else
            {
                BotCharacterRef.AimIK.solver.clampWeight = 
                    Mathf.SmoothDamp(BotCharacterRef.AimIK.solver.clampWeight, ClampWeight, ref velocity, WeightSmoothTime * Time.deltaTime);
                
                return TaskStatus.Failure;
            }
        }
    }
}