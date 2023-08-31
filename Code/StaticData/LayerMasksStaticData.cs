using UnityEngine;

namespace _GAME.Code.StaticData
{
    [CreateAssetMenu(fileName = "Layer Masks Static Data", menuName = "Static Data/Layer Masks Static Data")]
    public class LayerMasksStaticData : ScriptableObject
    {
        public LayerMask InteractionRaycastMask;
        public LayerMask IngnoreRaycastMask;
    }
}