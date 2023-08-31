using UnityEngine;

namespace _GAME.Code.Logic.Character.Animation
{
    public class CharacterAnimator : MonoBehaviour
    {
        public Animator Animator;
        
        public float StrafeAnimationLerpValue;
        
        public void SetActiveIdleAnimation(bool activeMode)
        {
            Animator.SetBool(CharacterAnimationStates.Idle.ToString(), activeMode);
        }
        public void SetActiveMoveAnimation(bool activeMode)
        {
            Animator.SetBool(CharacterAnimationStates.Move.ToString(), activeMode);
        }
        
        public void SetActiveWeaponAim(bool activeMode)
        {
            Animator.SetBool(CharacterAnimationStates.Aim.ToString(), activeMode);
        }

        public void SetWeaponId(int id)
        {
            Animator.SetInteger(CharacterAnimationStates.WeaponId.ToString(), id);
        }
        
        // public void SetActiveAttackAnim()
        // {
        //     Animator.SetTrigger(CharacterAnimationStates.Attack.ToString());
        // }
        public void SetActiveAttackAnim(bool activeMode)
        {
            Animator.SetBool(CharacterAnimationStates.Attack.ToString(), activeMode);
        }

        // Strafe
        public void SetStrafeActive(bool activeMode)
        {
            Animator.SetBool(CharacterAnimationStates.Strafe.ToString(), activeMode);
        }
        public void SetStrafeX(float value)
        {
            Animator.SetFloat(CharacterAnimationStates.Strafe_X.ToString(), value);
        }
        public void SetStrafeY(float value)
        {
            Animator.SetFloat(CharacterAnimationStates.Strafe_Y.ToString(), value);
        }
        public float GetStrafeX()
        {
            float value = Animator.GetFloat(CharacterAnimationStates.Strafe_X.ToString());
            
            return value;
        }
        public float GetStrafeY()
        {
            float value = Animator.GetFloat(CharacterAnimationStates.Strafe_Y.ToString());
        
            return value; 
        }
    }
}