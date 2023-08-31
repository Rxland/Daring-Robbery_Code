using System.Collections.Generic;
using _GAME.Code.Logic.Interaction.Interactables;
using UnityEngine;

namespace _GAME.Code.StaticData
{
    [CreateAssetMenu(fileName = "Safe Deposit Static Data", menuName = "Static Data/Safe Deposit")]
    public class SafeDepositStaticData : ScriptableObject
    {
        public List<Treasure> SafeDepositRandomInBoxTreasures;
        [Space]
        
        [Range(0, 100)]
        public int CanInteractWithDepositBoxesAmountPercentage;
    }
}