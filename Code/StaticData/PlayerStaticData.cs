using _GAME.Code.Logic;
using _GAME.Code.UI;
using UnityEngine;

namespace _GAME.Code.StaticData
{
    [CreateAssetMenu(fileName = "Player Static Data", menuName = "Static Data/Player")]
    public class PlayerStaticData : ScriptableObject
    {
        public GameObject Prefab;

        
        [Header("Set up")]
        public float MaxHp;
        
        [Header("Stolen Bag Settting")]
        public Backpack BagPrefab;
        public int MaxBackPacks;
        public float BagSpawnYPosOffset;
        public float BagForceSpeed;
        
        [Header("Hit")]
        public HitEnemyIndicator HitEnemyIndicator;
    }
}