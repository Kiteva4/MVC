using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public sealed class EnemySpawnController : IExecute
    {
        CompositeMove _enemies;
        IEnemyFactory _enemyFactory;
        Transform _enemiesPlaceHolder;
        Data _data;

        public EnemySpawnController(CompositeMove enemies, Data data, Transform enemiesPlaceHolder)
        {
            _enemies = enemies;
            _data = data;
            _enemiesPlaceHolder = enemiesPlaceHolder;

            _enemyFactory = new EnemyFactory();
        }

        public void Execute(float deltaTime)
        {
            if (_enemies.isEmpty)
            {
                _enemies.AddUnit(_enemyFactory.CreateEnemy(_data.Enemy, EnemyType.Small, _enemiesPlaceHolder));
            }
        }
    }
}