using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public sealed class ShootController : IExecute, ICleanup, IInitialization
    {
        private bool _isFire;
        private BulletsType _generatedBulletsType;

        private readonly IUserInputProxy<bool> _fireInputProxy;
        private readonly IBulletFactory _bulletFactory;
        private readonly BulletsData _bulletsData;

        private Stack<BulletProvider> _bulletsPool;
        private Queue<BulletProvider> _activeBulletsOnScene;
        
        private bool PollIsEmpty => _bulletsPool.Count == 0;
        
        public ShootController(IUserInputProxy<bool> fireInputProxy, IBulletFactory bulletFactory,
            BulletsData bulletsData)
        {
            _fireInputProxy = fireInputProxy;
            _bulletFactory = bulletFactory;
            _bulletsData = bulletsData;
            _generatedBulletsType = BulletsType.Single;

            _bulletsPool = new Stack<BulletProvider>(_bulletsData.MaxBulletsInPool);
            
            _fireInputProxy.AxisOnChange += FireOnAxisOnChange;
        }

        void FireOnAxisOnChange(bool isFire)
        {
            _isFire = isFire;
        }

        public void Execute(float deltaTime)
        {
            if (_isFire)
            {
                Debug.Log("Fire");
                Shoot();
            }
        }

        public void Cleanup()
        {
            _fireInputProxy.AxisOnChange -= FireOnAxisOnChange;
        }

        public void Initialization()
        {
            for (int i = 0; i < _bulletsData.MaxBulletsInPool; i++)
            {
                var bullet = _bulletFactory.CreateBullet(_bulletsData, _generatedBulletsType) as BulletProvider;
                bullet.gameObject.SetActive(false);
                _bulletsPool.Push(bullet);
            }
        }

        private void OnWeaponChange()
        {
        }

        private void Shoot()
        {
            if (_activeBulletsOnScene.Count < _bulletsData.MaxBulletsInPool)
            {
                if (!PollIsEmpty)
                {
                    var bullet = _bulletsPool.Pop();
                    bullet.gameObject.SetActive(true);
                    _activeBulletsOnScene.Enqueue(bullet);
                }
                else
                {
                    var bullet = _bulletFactory.CreateBullet(_bulletsData, _generatedBulletsType) as BulletProvider;
                    bullet.gameObject.SetActive(true);
                }
            }
            else
            {
                var bullet = _activeBulletsOnScene.Dequeue();
                bullet.gameObject.SetActive(true);
                _activeBulletsOnScene.Enqueue(bullet);
            }
        }
    }
}