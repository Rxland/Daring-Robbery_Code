using UnityEngine;

namespace _GAME.Code.StaticData
{
    [CreateAssetMenu(fileName = "Heist Static Data", menuName = "Static Data/Heist Static Data")]
    public class HeistStaticData : ScriptableObject
    {
        public int DollarusAmountToCanEndHeist;
    }
}