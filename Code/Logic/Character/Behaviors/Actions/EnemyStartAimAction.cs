namespace _GAME.Code.Logic.Character.Behaviors.Actions
{
    public class EnemyStartAimAction : CharacterAction
    {
        public override void OnStart()
        {
            BotCharacterRef.CharacterAnimator.SetActiveWeaponAim(true);
        }

    }
}