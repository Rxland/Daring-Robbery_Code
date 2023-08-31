using RootMotion.FinalIK;
using UnityEngine;

namespace _GAME.Code.Logic.Enemy
{
    public class EnemyIkController : MonoBehaviour
    {
        public AimIK AimIk;
        public LookAtIK LookAt;
        public Animator Animator;
        
        public float MinAimDistance = 0.5f;
        public float TargetOutSideAimIkWeight;
        public float MaxYAngel;
        public float LerpSpeedValue;

        public bool IsOutOffAngle;
        
        private void LateUpdate()
        {
            AimUpdate();
        }

        private void AimUpdate()
        {
            LimitAimTarget();
            
            Vector3 direction = (AimIk.solver.target.position - AimIk.solver.bones[0].transform.position);
            Vector3 localDirection = transform.InverseTransformDirection(direction);
            
            
            float angle = Vector3.Angle(direction, transform.forward);

            if (angle > MaxYAngel)
            {
                AimIk.solver.clampWeight = Mathf.Lerp(AimIk.solver.clampWeight, 1f, Time.deltaTime * LerpSpeedValue);
                LookAt.solver.IKPositionWeight = Mathf.Lerp(LookAt.solver.IKPositionWeight, 0f, Time.deltaTime * LerpSpeedValue);

                IsOutOffAngle = true;
            }
            else
            {
                AimIk.solver.clampWeight = Mathf.Lerp(AimIk.solver.clampWeight, 0.2f, Time.deltaTime * LerpSpeedValue);
                LookAt.solver.IKPositionWeight = Mathf.Lerp(LookAt.solver.IKPositionWeight, 1f, Time.deltaTime * LerpSpeedValue);
                
                IsOutOffAngle = false;
            }
        }
        
        void LimitAimTarget() {
            Vector3 aimFrom = AimIk.solver.bones[0].transform.position;
            Vector3 direction = (AimIk.solver.target.position - aimFrom);
            direction = direction.normalized * Mathf.Max(direction.magnitude, MinAimDistance);
			
            AimIk.solver.target.position = aimFrom + direction;
        }
    }
}