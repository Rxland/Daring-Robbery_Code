using System;
using _GAME.Code.Data.VFX;
using _GAME.Code.Features;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Logic.Game_Behavior;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Interaction
{
    public abstract class Interactable : MonoBehaviour
    {
        public InteractionType InteractionType;
        public bool CanInteract = true;
        public bool IsNeedCheckView = true;
        public VfxType PickUpVfxType;
        public SpriteRenderer SpriteIteractIndicator;
        public AudioSource InteractSound;
        
        [EnableIf(nameof(InteractionType), InteractionType.CircleTime)]
        public float InteractionDuration;
        [Space]
        
        [Header("Ui Indicator")]
        public Vector3 UiIndicationOffset = new Vector3(0f, 0.25f, 0f);

        public Action InteractableDoneEvent;

        protected EnvFactory EnvFactory;
        protected VfxFactory VfxFactory;
        protected GameFactory GameFactory;
        protected SoundFactory SoundFactory;
        protected StaticDataService StaticDataService;
        protected InventoryFeature InventoryFeature;
        protected HudUiFeature HudUiFeature;
        protected RunTimeDataFeature RunTimeDataFeature;
        protected GameBehavior GameBehavior;

        [Inject]
        public virtual void Constructor(VfxFactory vfxFactory,
                                        GameFactory gameFactory, 
                                        StaticDataService staticDataService,
                                        InventoryFeature inventoryFeature,
                                        HudUiFeature hudUiFeature,
                                        SoundFactory soundFactory,
                                        RunTimeDataFeature runTimeDataFeature,
                                        GameBehavior gameBehavior,
                                        EnvFactory envFactory
                                        )
        {
            VfxFactory = vfxFactory;
            GameFactory = gameFactory;
            StaticDataService = staticDataService;
            InventoryFeature = inventoryFeature;
            HudUiFeature = hudUiFeature;
            SoundFactory = soundFactory;
            RunTimeDataFeature = runTimeDataFeature;
            GameBehavior = gameBehavior;
            EnvFactory = envFactory;
        }

        protected virtual void Start()
        {
            if (!CanInteract)
            {
                if (SpriteIteractIndicator) SpriteIteractIndicator.gameObject.SetActive(false);
            }
        }

        public abstract void Interact(Transform whoInteractT);

        public virtual void Interact()
        {
            InteractSound?.Play();
        }

        public virtual bool CheckCanInteract() { return true; }

        protected virtual void SpawnPickUpEffect()
        {
            VfxFactory.SpawnEffectByType(PickUpVfxType, transform.position, transform.rotation, 2f);
        }

        public bool IsInView()
        {
            if (!IsNeedCheckView) return true;
            
            Vector3 viewportPosition = GameFactory.PlayerCamera.WorldToViewportPoint(transform.position);

            if (viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
                viewportPosition.y >= 0 && viewportPosition.y <= 1)
            {
                Ray ray = GameFactory.PlayerCamera.ViewportPointToRay(viewportPosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, StaticDataService.LayerMasksStaticData.InteractionRaycastMask))
                {
                    if (hit.collider.gameObject == gameObject)
                        return true;
                    
                    return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}