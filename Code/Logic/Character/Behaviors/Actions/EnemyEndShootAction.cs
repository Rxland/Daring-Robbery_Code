namespace _GAME.Code.Logic.Character.Behaviors.Actions
{
    public class EnemyEndShootAction: CharacterAction
    {
        public override void OnStart()
        {
            BotCharacterRef.CharacterAnimator.SetActiveAttackAnim(false);
        }
    }
}