using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Actions.Bot_AI
{
    public class SetAimTargetPosToIdlePos : CharacterAction
    {
        public override void OnStart()
        {
            base.OnStart();

            Vector3 aimTpos = BotCharacterRef.CenterPoint.localPosition;
            aimTpos.z += 2f;

            BotCharacterRef.AimTarget.transform.localPosition = aimTpos;
        }
    }
}