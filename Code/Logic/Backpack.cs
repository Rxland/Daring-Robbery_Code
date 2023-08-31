using _GAME.Code.Data.Sound;
using _GAME.Code.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic
{
    public class Backpack : MonoBehaviour
    {
        public Rigidbody Rigidbody;
        
        private bool _backpackDropped;

        [Inject] private SoundFactory _soundFactory;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (_backpackDropped) return;
            _backpackDropped = true;

            _soundFactory.CreateSoundByName(SoundName.Backpack_drop_1, transform.position, 1f);
        }
    }
}