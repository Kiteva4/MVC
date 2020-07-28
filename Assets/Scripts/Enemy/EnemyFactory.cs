using UnityEngine;

namespace MVCExample
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        public IEnemy CreateEnemy(EnemyData data, EnemyType type, object placeHolder)
        {
            var enemyProvider = data.GetEnemy(type);
            Vector3 pos = new Vector3(Random.Range(-10.0f, 10.0f),Random.Range(-10.0f, 10.0f),0.0f);
            return Object.Instantiate( enemyProvider, pos, Quaternion.identity, placeHolder as Transform);
        }
    }
}
