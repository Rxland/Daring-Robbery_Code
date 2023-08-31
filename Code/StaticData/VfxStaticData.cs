using System.Collections.Generic;
using _GAME.Code.Data.VFX;
using UnityEngine;

namespace _GAME.Code.StaticData
{
    [CreateAssetMenu(fileName = "VFX static data", menuName = "Static Data/VFX")]
    public class VfxStaticData : ScriptableObject
    {
        public List<VfxStaticDataData> VfxDataList;
    }
}