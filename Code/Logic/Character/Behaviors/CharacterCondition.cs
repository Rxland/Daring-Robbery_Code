using _GAME.Code.Logic.Character.Ref;
using BehaviorDesigner.Runtime.Tasks;

namespace _GAME.Code.Logic.Character.Behaviors
{
    public class CharacterCondition : Conditional
    {
        public BotCharacterRef BotCharacterRef;

        public override void OnAwake()
        {
            BotCharacterRef = GetComponent<BotCharacterRef>();
        }
    }
}