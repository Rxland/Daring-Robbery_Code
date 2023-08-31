using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Logic.Character.Ref;
using BehaviorDesigner.Runtime.Tasks;
using Zenject;

namespace _GAME.Code.Logic.Character.Behaviors
{
    public class CharacterAction : Action
    {
        public BotCharacterRef BotCharacterRef;

        
        public override void OnAwake()
        {
            BotCharacterRef = GetComponent<BotCharacterRef>();
        }
    }
}
