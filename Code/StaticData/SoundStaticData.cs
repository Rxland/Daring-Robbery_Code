using System.Collections.Generic;
using _GAME.Code.Data.Sound;
using UnityEngine;

namespace _GAME.Code.StaticData
{
    [CreateAssetMenu(fileName = "Sound Static Data", menuName = "Static Data/Sound")]
    public class SoundStaticData : ScriptableObject
    {
        public List<SoundStaticDataData> SoundList;
    }
}