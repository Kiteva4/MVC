using UnityEngine;

namespace MVCExample
{
    public sealed class EnemySpawnController : IExecute
    {
        private readonly CompositeMove _enemies;
        private readonly IEnemyFactory _enemyFactory;
        private readonly Transform _enemiesPlaceHolder;
        private readonly Data _data;

        public EnemySpawnController(CompositeMove enemies, 
            IEnemyFactory enemyFactory, 
            Data data,
            Transform enemiesPlaceHolder)
        {
            _enemies = enemies;
            _data = data;
            _enemiesPlaceHolder = enemiesPlaceHolder;
            _enemyFactory = enemyFactory;
        }

        public void Execute(float deltaTime)
        {
            if (_enemies.IsEmpty)
            {
                _enemies.AddUnit(_enemyFactory.CreateEnemy(_data.Enemy, EnemyType.Small, _enemiesPlaceHolder));
            }
        }
    }
}