using DG.Tweening;

namespace _GAME.Code.Logic.Character.Behaviors.Actions
{
    public class EnemyEndAimIkAction : CharacterAction
    {
        public override void OnStart()
        {
            DOVirtual.Float(BotCharacterRef.AimIK.solver.IKPositionWeight, 0f, 0.2f, (float value) => BotCharacterRef.AimIK.solver.SetIKPositionWeight(value));
        }
    }
}