using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Logic.Game_Behavior;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Interaction.Bullet_Interaction
{
    public abstract class BulletInteractableBase : MonoBehaviour
    {
        [Inject] public GameBehavior GameBehavior;
        [Inject] public SoundFactory SoundFactory;
        
        public abstract void Interact();
        public abstract void Interact(Transform interactor);
    }
}