using System;
using System.Collections;
using System.Collections.Generic;
using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Logic.Enemy;
using _GAME.Code.Logic.Game_Behavior;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _GAME.Code.Logic.Env.Enemies
{
    public class EnemiesWaveSpawnSystem : MonoBehaviour
    {
        public int MaxEnemiesOnLevel;
        
        [Header("Timing")]
        [ReadOnly] [ShowInInspector] private float _spawningTime;
        [Space]
        
        [SerializeField] private float _spawningDelayTime;
        [SerializeField] private float _decreaseSpawingDelayValueAfterEachSpawn;
        [SerializeField] private float _minSpawningDelayTime;
        [ReadOnly] private float _spawnFireTime;
        [Space]
        
        [SerializeField] private List<SpawnerWaveData> _spawnerWaveData;
        [ReadOnly] [ShowInInspector] private SpawnerWaveData _currentWaveData;

        [Inject] private EnvFactory _envFactory;
        [Inject] private GameFactory _gameFactory;
        [Inject] private GameBehavior _gameBehavior;
        
        
        private void Awake()
        {
            ResetSpawnFireTime();
        }

        private void Start()
        {
            _currentWaveData = _spawnerWaveData[0];
        }

        private void Update()
        {
            Spawning();
        }

        private void Spawning()
        {
            if (!_envFactory.Level || !_gameBehavior.IsHeistStarted || _envFactory.Level.AllSpawnedEnemies.Count >= MaxEnemiesOnLevel) return;
            
            _spawningTime += Time.deltaTime;
            
            if (_spawnFireTime > 0)
            {
                _spawnFireTime -= Time.deltaTime;
                return;
            }

            DecreaseSpawningDelay();
            ResetSpawnFireTime();
            TrySwitchCurrentSpawnerWaveData();
            StartCoroutine(SpawnEnemiesIE());
        }

        private IEnumerator SpawnEnemiesIE()
        {
            for (int i = 0; i < _currentWaveData.SpawnersCanSpawnAmount; i++)
            {
                EnemyWaveSpawner spawner = GetRandomEnemyWaveSpawnerByCurrentWaveData();
                EnemyType enemyTypeToSpawn = GetRandomEnemyTypeByCurrentWaveData();
                
                spawner.Spawn(enemyTypeToSpawn);

                yield return new WaitForSeconds(Random.Range(0.3f, 1f));
            }
        }

        private void TrySwitchCurrentSpawnerWaveData()
        {
            foreach (SpawnerWaveData spawnerWaveData in _spawnerWaveData)
            {
                if (_spawningTime >= spawnerWaveData.StartSpawnTime)
                    _currentWaveData = spawnerWaveData;
            }
        }
        
        private void ResetSpawnFireTime()
        {
            _spawnFireTime = _spawningDelayTime;
        }
        
        private void DecreaseSpawningDelay()
        {
            _spawningDelayTime = Mathf.Clamp(_spawningDelayTime - _decreaseSpawingDelayValueAfterEachSpawn, _minSpawningDelayTime, float.MaxValue);
        }
        
        private EnemyWaveSpawner GetRandomEnemyWaveSpawnerByCurrentWaveData()
        {
            return _envFactory.Level.EnemyWaveSpawners[Random.Range(0, _envFactory.Level.EnemyWaveSpawners.Count)];
        }
        
        private EnemyType GetRandomEnemyTypeByCurrentWaveData()
        {
            return _currentWaveData.EnemyTypesToSpawn[Random.Range(0, _currentWaveData.EnemyTypesToSpawn.Count)];
        }
        
    }
}