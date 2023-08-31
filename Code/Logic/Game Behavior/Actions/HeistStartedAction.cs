using UnityEngine;

namespace _GAME.Code.Logic.Game_Behavior.Actions
{
    public class HeistStartedAction : GameBehaviorAction
    {
        public override void OnStart()
        {
            GameBehavior.GameFactory.Player.Character.OnHolster(false);
        }
    }
}