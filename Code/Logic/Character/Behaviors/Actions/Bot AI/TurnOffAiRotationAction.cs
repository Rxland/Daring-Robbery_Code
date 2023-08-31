using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Actions.Bot_AI
{
    public class TurnOffAiRotationAction : CharacterAction
    {
        public override void OnStart()
        {
            BotCharacterRef.AIPath.enableRotation = false;
        }
    }
}