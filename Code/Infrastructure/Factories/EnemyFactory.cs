using System.Collections.Generic;
using _GAME.Code.Infrastructure.Services;
using _GAME.Code.Logic.Character.Ref;
using _GAME.Code.Logic.Enemy;
using _GAME.Code.Logic.Env.Enemies;
using _GAME.Code.StaticData;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Infrastructure.Factories
{
    public class EnemyFactory : IService
    {
        [Inject] private StaticDataService _staticDataService;
        [Inject] private GameFactory _gameFactory;
        [Inject] private DiContainer _diContainer;
        [Inject] private EnvFactory _envFactory;
        
        
        public void SpawnEnemy(EnemyType enemyType, Vector3 pos)
        {
            EnemyStaticData enemyStaticData = _staticDataService.ReturnEnemyStaticDataByType(enemyType);
            BotCharacterRef botCharacterRef = _diContainer.InstantiatePrefabForComponent<BotCharacterRef>(enemyStaticData.Prefab);
            
            botCharacterRef.transform.position = pos;
            botCharacterRef.PlayerTarget = _gameFactory.Player.transform;
            botCharacterRef.AiAttack.SetWeaponByName(enemyStaticData.WeaponToSelect[Random.Range(0, enemyStaticData.WeaponToSelect.Count)]);
            botCharacterRef.Stats.MaxHp = enemyStaticData.MaxHp;
            botCharacterRef.AiAttack.CurrentWeapon.spread = enemyStaticData.AimSpread;
            
            _envFactory.Level.AllSpawnedEnemies.Add(botCharacterRef);
        }

        public void RemoveEnemy(BotCharacterRef botCharacterRef)
        {
            _envFactory.Level.AllSpawnedEnemies.Remove(botCharacterRef);
            GameObject.Destroy(botCharacterRef.gameObject, 3f);
        }
        
        public void SpawnStaticEnemies()
        {
            foreach (EnemyStaticSpawner enemySpawner in _envFactory.Level.EnemyStaticSpawners)
            {
                enemySpawner.Spawn();
            }
        }
    }
}