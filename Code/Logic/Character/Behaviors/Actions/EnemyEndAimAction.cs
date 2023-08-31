namespace _GAME.Code.Logic.Character.Behaviors.Actions
{
    public class EnemyEndAimAction : CharacterAction
    {
        public override void OnStart()
        {
            BotCharacterRef.CharacterAnimator.SetActiveWeaponAim(false);
        }
    }
}