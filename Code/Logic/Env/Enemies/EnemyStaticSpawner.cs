using _GAME.Code.Infrastructure.Factories;
using _GAME.Code.Logic.Enemy;
using UnityEngine;
using Zenject;

namespace _GAME.Code.Logic.Env.Enemies
{
    public class EnemyStaticSpawner : MonoBehaviour
    {
        public EnemyType EnemyType;

        [Inject] private EnemyFactory _enemyFactory;
        
        
        public void Spawn()
        {
            _enemyFactory.SpawnEnemy(EnemyType, transform.position);
        }
    }
}