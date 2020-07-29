using UnityEngine;

namespace MVCExample
{
    public class BulletFactory : IBulletFactory
    {
        public IBullet CreateBullet(BulletsData data, BulletsType type)
        {
            var bulletProvider = data.GetBullet(type);
            return Object.Instantiate( bulletProvider, Vector3.zero, Quaternion.identity);
        }
    }
}