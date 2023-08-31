using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Actions
{
    public class EnemyStrafeAction : CharacterAction
    {
        public override void OnStart()
        {
            Vector3 offset = BotCharacterRef.AIPath.destination - transform.position;
            offset.y = 0; // ignore vertical distance
            float distance = offset.magnitude;
            Vector3 direction = offset.normalized;
            
            float angle = Vector3.SignedAngle(BotCharacterRef.Spine1T.forward, direction, Vector3.up);

            float xBlend = Mathf.Clamp(angle / 45f, -1f, 1f);
            float zBlend = Mathf.Clamp(distance / 10f, -1f, 1f);

            xBlend = Mathf.Round(xBlend);
            zBlend = Mathf.Round(zBlend);
            
            float newStrafeX = 0f;
            float newStrafeY = 0f;
            
            // if (!float.IsNaN(xBlend))
            //     newStrafeX = Mathf.Lerp(BotCharacterRef.CharacterAnimator.GetStrafeX(), xBlend, 5 * Time.deltaTime);
            //
            // if (!float.IsNaN(zBlend))
            //     newStrafeY = Mathf.Lerp(BotCharacterRef.CharacterAnimator.GetStrafeY(), zBlend, 5 * Time.deltaTime);
            
            // BotCharacterRef.CharacterAnimator.SetStrafeX(xBlend);
            // BotCharacterRef.CharacterAnimator.SetStrafeY(zBlend);
        }
    }
}