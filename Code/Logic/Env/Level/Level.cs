using System.Collections.Generic;
using _GAME.Code.Logic.Character.Ref;
using _GAME.Code.Logic.Env.Enemies;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME.Code.Logic.Env.Level
{
    public class Level : MonoBehaviour
    {
        public int Level_id;
        [Space]
        
        [Space] 
        public EnemiesWaveSpawnSystem EnemiesWaveSpawnSystem;
        
        public Transform PlayerSpawnPoint;
        [Space] 
        
        [Header("Enemies")]
        public List<EnemyWaveSpawner> EnemyWaveSpawners;
        public List<EnemyStaticSpawner> EnemyStaticSpawners;
        [ReadOnly] public List<BotCharacterRef> AllSpawnedEnemies;

        [Header("Customers")] 
        public List<Transform> CustomersRunToPointsList;

        [Header("Transport")] 
        public Van Van;
        public ExitHeistCar ExitHeistCar;
    }
}