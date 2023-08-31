using _GAME.Code.Data;
using _GAME.Code.Features;
using _GAME.Code.StaticData.Weapon_Stuff;
using _GAME.Code.UI.Top_Navigation;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace _GAME.Code.UI.Windows.Invenotory
{
    public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Button Button;
        public Image ItemImg;
        public TextMeshProUGUI ItemNameText;
        [Space]
        
        public Image MainWeaponEquipedImg;
        public Image SecondaryWeaponEquipedImg;

        [Header("Interact")] 
        public Transform InteractButtonsContainer;
        public Button EquipButton;
        public Button UpgradeButton;

        [Header("Stored Data")] 
        [ReadOnly] public WeaponStaticData StoredWeaponStaticData;
        [ReadOnly] public WeaponsSaveData StoredWeaponsSaveData;
        
        private bool isPointerOverButton = false;

        [Inject] private WeaponsFeature _weaponsFeature;
        [Inject] private UiFeature _uiFeature;
        [Inject] private MainMenuWindowsController _mainMenuWindowsController;
        
        private void Awake()
        {
            InitButtons();
        }

        private void Update()
        {
            if (!isPointerOverButton && Input.GetMouseButtonDown(0))
            {
                isPointerOverButton = true;
                
                CloseInteractButtonsContainer();
            }
        }

        private void InitButtons()
        {
            Button.onClick.AddListener(OpenInteractButtonsContainer);
            
            EquipButton.onClick.AddListener(() =>
            {
                _weaponsFeature.EquipWeapon(StoredWeaponsSaveData);
                _uiFeature.InventoryWindow.UpdateInventoryItemsEquipState();
            });
            UpgradeButton.onClick.AddListener(() =>
            {
                _mainMenuWindowsController.OpenWindowByWindowType(WindowsType.UpgradeWeapon);
            });
        }
        
        private void OpenInteractButtonsContainer()
        {
            if (StoredWeaponsSaveData.IsEquipped)
                EquipButton.gameObject.SetActive(false);
            else
                EquipButton.gameObject.SetActive(true);
            
            InteractButtonsContainer.gameObject.SetActive(true);
            InteractButtonsContainer.transform.localScale = new Vector3(1f, 0f, 1f);
            InteractButtonsContainer.transform.DOScaleY(1f, 0.2f).SetEase(Ease.OutBack);
        }

        private void CloseInteractButtonsContainer()
        {
            InteractButtonsContainer.transform.DOScaleY(0f, 0.2f).SetEase(Ease.InBack);
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            isPointerOverButton = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isPointerOverButton = false;
        }
    }
}