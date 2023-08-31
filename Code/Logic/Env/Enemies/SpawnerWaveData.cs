using System;
using System.Collections.Generic;
using _GAME.Code.Logic.Enemy;

namespace _GAME.Code.Logic.Env.Enemies
{
    [Serializable]
    public class SpawnerWaveData
    {
        public List<EnemyType> EnemyTypesToSpawn;
        public float StartSpawnTime;
        public int SpawnersCanSpawnAmount;
    }
}