namespace _GAME.Code.Logic.Character.Behaviors.Actions
{
    public class EnemyStartShootAction : CharacterAction
    {
        public override void OnStart()
        {
            BotCharacterRef.CharacterAnimator.SetActiveAttackAnim(true);
        }
    }
}