using BehaviorDesigner.Runtime.Tasks;

namespace _GAME.Code.Logic.Game_Behavior.Conditions
{
    public class GameBehaviorCondition : Conditional
    {
        public GameBehavior GameBehavior;

        public override void OnAwake()
        {
            GameBehavior = GetComponent<GameBehavior>();
        }
    }
}