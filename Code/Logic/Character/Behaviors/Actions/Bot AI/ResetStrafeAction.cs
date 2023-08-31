
namespace _GAME.Code.Logic.Character.Behaviors.Actions.Bot_AI
{
    public class ResetStrafeAction : CharacterAction
    {
        public override void OnStart()
        {
            BotCharacterRef.IsStrafing = false;
        }
    }
}