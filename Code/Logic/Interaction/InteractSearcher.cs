using _GAME.Code.Features;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Logic.Character.Ref;
using _GAME.Code.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Interaction
{
    public class InteractSearcher : MonoBehaviour
    {
        private PlayerCharacterRef _playerCharacterRef;
        
        public LayerMask InteractionsLayerMask;
        public float InteractionRange;
        
        private Interactable _interactable;
        private GameObject _interactableObject = null;
        [ReadOnly] public bool IsInteracting;

        private float _interactionFireTime;
        
        private InteractionUiFeature interactionUiFeature;
        private InteractionsUiRef _interactionsUiRef;
        private StaticDataService _staticDataService;
        private HudUiFeature _hudUiFeature;
        private GameFactory _gameFactory;
        private HudUiRef _hudUiRef;
        

        [Inject]
        private void Constructor(InteractionUiFeature interactionUiFeature, 
                                InteractionsUiRef interactionsUiRef,
                                StaticDataService staticDataService,
                                HudUiFeature hudUiFeature,
                                GameFactory gameFactory,
                                HudUiRef hudUiRef
                                )
        {
            this.interactionUiFeature = interactionUiFeature;
            _interactionsUiRef = interactionsUiRef;
            _staticDataService = staticDataService;
            _hudUiFeature = hudUiFeature;
            _gameFactory = gameFactory;
            _hudUiRef = hudUiRef;
        }

        private void Awake()
        {
            _playerCharacterRef = GetComponent<PlayerCharacterRef>();
        }

        private void Update()
        {
            SearchInteractions();
            TryInteract();
        }

        private void TryInteract()
        {
            if (_interactable == null)
            {
                InteractionEndLogic();
                return;
            }
            
            if (Input.GetKeyUp(KeyCode.F))
            {
                switch(_interactable.InteractionType)
                {
                    case InteractionType.CircleTime:
                        _interactionsUiRef.CircleInteractionFilledImg.fillAmount = 0f;
                        break;
                }
                InteractionEndLogic();
                _hudUiFeature.SetActiveCrosshair(true);
            }
            
            if (!_interactable.CanInteract) return;
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                switch(_interactable.InteractionType)
                {
                    case InteractionType.Fast:
                        IntearctHandler(transform);
                        break;
                    case InteractionType.CircleTime:
                        _interactionFireTime = 0f;
                        break;
                }
                InteractionStartLogic();
            }
            
            if (Input.GetKey(KeyCode.F))
            {
                if (_interactable == null || !_interactable.CheckCanInteract()) return;
                
                switch(_interactable.InteractionType)
                {
                    case InteractionType.CircleTime:
                        if (_interactionFireTime >= _interactable.InteractionDuration)
                        {
                            IntearctHandler(transform);
                            _interactionFireTime = 0f;
                            _interactionsUiRef.CircleInteractionFilledImg.fillAmount = 0f;
                        }
                        else
                        {
                            _interactionFireTime += Time.deltaTime;
                            
                            _interactionsUiRef.CircleInteractionFilledImg.fillAmount =
                                _interactionFireTime / _interactable.InteractionDuration;
                        }
                        break;
                }
                InteractionStartLogic();
            }
        }

        private void IntearctHandler(Transform interactableTransform)
        {
            _interactable.Interact(interactableTransform);
            _interactable.Interact();
            ClearInteract();
        }
        
        private void SearchInteractions()
        {
            if (IsInteracting) return;
            
            Collider[] colliders = Physics.OverlapSphere(transform.position, InteractionRange, InteractionsLayerMask);

            if (colliders.Length == 0)
            {
                ClearInteract();
                return;
            }
            
            _interactableObject = colliders[0].gameObject;

            float distance = float.MaxValue;
            
            foreach (Collider collider in colliders)
            {
                Vector3 screenPos = _gameFactory.PlayerCamera.WorldToScreenPoint(collider.transform.position);
                
                float interactableObjectDistnace = Vector3.Distance(screenPos, _hudUiRef.CrosshairImg.transform.position);
                
                if (interactableObjectDistnace < distance)
                {
                    distance = interactableObjectDistnace;
                    _interactableObject = collider.gameObject;
                }
            }

            if (_interactableObject)
            {
                _interactable = _interactableObject.GetComponent<Interactable>();
                
                if (_interactable.CanInteract && _interactable.IsInView())
                {
                    Vector3 pos = _interactableObject.transform.position + _interactable.UiIndicationOffset;
                    float yOffset = _interactable.UiIndicationOffset.y;
                    
                    interactionUiFeature.ShowInteractUiObject(pos, yOffset);
                }
                else
                {
                    _interactable = null;
                    _interactableObject = null;
                }
            }
        }

        private void ClearInteract()
        {
            _interactable = null;
            _interactableObject = null;
            interactionUiFeature.HideInteractUiObject();
        }
        private void InteractionStartLogic()
        {
            IsInteracting = true;
            _playerCharacterRef.Character.lowerWeapon.loweredPressed = true;
            _hudUiFeature.SetActiveCrosshair(false);
        }
        private void InteractionEndLogic()
        {
            IsInteracting = false;
            _playerCharacterRef.Character.lowerWeapon.loweredPressed = false;
        }
    }
}