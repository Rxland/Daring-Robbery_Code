using _GAME.Code.Logic.Env.Level;
using UnityEngine;

namespace _GAME.Code.StaticData
{
    [CreateAssetMenu(fileName = "Level Static Data", menuName = "Static Data/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public int Level_Id;
        public Level LevelPrefab;
    }
}