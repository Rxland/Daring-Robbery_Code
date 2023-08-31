using _GAME.Code.UI.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _GAME.Code.UI
{
    public class HudUiRef : MonoBehaviour
    {
        public TextMeshProUGUI StolenMoneyBagsAmountText;
        public MoneyAmountContainerRef MoneyAmountContainerRef;
        public PlayerHpBarLogic PlayerHpBarLogic;
        public Image FullScreenHpBloodImg;
        
        [Header("Images")]
        public Image CrosshairImg;
    }
}