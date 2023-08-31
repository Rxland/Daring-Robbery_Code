using UnityEngine;

namespace _GAME.Code.Logic.Character.Behaviors.Actions.Bot_AI
{
    public class TurnOnAiRotationAction : CharacterAction
    {
        public override void OnStart()
        {
            BotCharacterRef.AIPath.enableRotation = true;
        }
    }
}