using _GAME.Code.Types;
using _GAME.Code.UI.Windows;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _GAME.Code.UI.Shop
{
    public class ShopTabItemBase : MonoBehaviour
    {
        [ReadOnly] public ShopTabType TabType;
        [Space] 
        
        [SerializeField] private TextMeshProUGUI _tabNameText;
        [SerializeField] private MoneyAmountContainerRef _moneyAmountContainerRefPrice;
        
        [SerializeField] private Image _BgImg;
        [SerializeField] private Image _tabIcon;
        public Image SelectedImg;
        
        [Space]
        public Button TabClickButton;
        public CanvasGroup CanvasGroup;

        [Header("Params")] 
        [ReadOnly] public bool IsSelected;
        [ReadOnly] public bool IsUnlocked;
        
        [Header("Colors")]
        [SerializeField] private Color ItemSleletedBgColor;
        [SerializeField] private float _lockedCanvasGroupAlfaValue;
        private Color _itemDefaultBgColor;

        
        private void Awake()
        {
            TabClickButton.onClick.AddListener(ClickAnimation);
            _itemDefaultBgColor = _BgImg.color;
        }

        public void SetTabNameText(string tabName)
        {
            _tabNameText.text = tabName;
        }
        public void SetTabIconSprite(Sprite sprite)
        {
            _tabIcon.sprite = sprite;
        }

        public void SetPriceText(int price)
        {
            _moneyAmountContainerRefPrice.AmountText.text = price.ToString();
        }

        public void SetItemEquipMode(BuyEquipState buyEquipState)
        {
            bool activeMode = buyEquipState == BuyEquipState.Equiped;

            if (!IsUnlocked) activeMode = false;
            
            IsSelected = activeMode;
            SelectedImg.gameObject.SetActive(activeMode);
            _BgImg.color = activeMode ? ItemSleletedBgColor : _itemDefaultBgColor;
        }

        public void SetUnlockMode(bool activeMode)
        {
            IsUnlocked = activeMode;
            
            CanvasGroup.alpha = activeMode ? 1f : _lockedCanvasGroupAlfaValue;
            _moneyAmountContainerRefPrice.gameObject.SetActive(!activeMode);
            _tabNameText.gameObject.SetActive(activeMode);
        }
        
        public void Show()
        {
            transform.transform.localScale = Vector3.zero;
            gameObject.SetActive(true);

            DOTween.Sequence()
                .Append(transform.DOScale(1f, 0.2f));
        }

        private void ClickAnimation()
        {
            DOTween.Sequence()
                .Append(transform.DOScale(1.1f, 0.15f)).SetEase(Ease.OutBack)
                .Append(transform.DOScale(1f, 0.15f)).SetEase(Ease.OutBack);
        }
    }
}