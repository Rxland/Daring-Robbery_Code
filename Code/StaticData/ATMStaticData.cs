using System.Collections.Generic;
using _GAME.Code.Logic.Interaction.Interactables;
using UnityEngine;

namespace _GAME.Code.StaticData
{
    [CreateAssetMenu(fileName = "ATM Static Data", menuName = "Static Data/ATM")]
    public class ATMStaticData : ScriptableObject
    {
        public List<Treasure> TreasuresList;
    }
}