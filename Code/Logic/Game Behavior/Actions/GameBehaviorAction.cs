using BehaviorDesigner.Runtime.Tasks;

namespace _GAME.Code.Logic.Game_Behavior.Actions
{
    public class GameBehaviorAction : Action
    {
        public GameBehavior GameBehavior;

        public override void OnAwake()
        {
            GameBehavior = GetComponent<GameBehavior>();
        }
    }
}