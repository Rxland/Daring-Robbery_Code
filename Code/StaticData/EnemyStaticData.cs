using System.Collections.Generic;
using _GAME.Code.Logic.Enemy;
using _GAME.Code.Types.Weapon_Stuff;
using UnityEngine;

namespace _GAME.Code.StaticData
{
    [CreateAssetMenu(fileName = "Enemy Static Data", menuName = "Static Data/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyType EnemyType;
        public List<WeaponTypeName> WeaponToSelect;
        public GameObject Prefab;
        
        [Header("Set up")]
        public float MaxHp;
        public float AimSpread;
    }
}