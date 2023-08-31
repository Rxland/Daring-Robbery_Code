using System.Collections.Generic;
using _GAME.Code.Data.Sound;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Interaction.Bullet_Interaction
{
    public class GlassBulletInteractable : BulletInteractableBase
    {
        [SerializeField] private Transform _partsOfGlassContainer;
        [SerializeField] private List<Rigidbody> _partsOfGlass;

        [SerializeField] private float _radius;
        [SerializeField] private float _power;

        [ReadOnly] private bool _canInteract = true;

        public override void Interact() {}

        [Button]
        public override void Interact(Transform interactor)
        {
            if (!_canInteract || !GameBehavior.IsHeistStarted) return;

            _canInteract = false;
            
            _partsOfGlassContainer.SetParent(null);
            _partsOfGlassContainer.gameObject.SetActive(true);
            
            foreach (Rigidbody glassRb in _partsOfGlass)
            {
                glassRb.isKinematic = false;
                glassRb.AddExplosionForce(_power, interactor.transform.position, _radius);
            }

            SoundFactory.CreateSoundByName(SoundName.Glass_Shatter_1, interactor.transform.position, 3f);
            
            Destroy(_partsOfGlassContainer.gameObject, 5f);
            Destroy(gameObject);
        }
    }
}