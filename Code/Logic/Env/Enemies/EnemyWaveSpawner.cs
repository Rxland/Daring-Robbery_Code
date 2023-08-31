using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Logic.Enemy;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Env.Enemies
{
    public class EnemyWaveSpawner : MonoBehaviour
    {
        [Inject] private EnemyFactory _enemyFactory;
        
        
        public void Spawn(EnemyType enemyType)
        {
            _enemyFactory.SpawnEnemy(enemyType, transform.position);
        }
    }
}