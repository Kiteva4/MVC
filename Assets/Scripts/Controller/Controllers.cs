using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public sealed class Controllers : IInitialization, ICleanup
    {
        private readonly IExecute[] _executeControllers;

        public int Length => _executeControllers.Length;

        public IExecute this[int index] => _executeControllers[index];

        public Controllers(Data data)
        {
            var pcInputHorizontal = new PCInputHorizontal();
            var pcInputVertical = new PCInputVertical();
            var pcInputFire = new PCInputFire();

            IPlayerFactory playerFactory = new PlayerFactory(data.Player);
            var player = playerFactory.CreatePlayer();

            var enemiesPlaceHolder = new GameObject("enemiesPlaceHolder");
            Object.Instantiate(data.Enviroment.spaceParticle, enemiesPlaceHolder.transform);

            var enemies = new CompositeMove();
            var enemyFactory = new EnemyFactory();
            var bulletFactory = new BulletFactory();

            var controllers = new List<IExecute>
            {
                new InputController(pcInputHorizontal, pcInputVertical, pcInputFire),
                new MoveController(pcInputHorizontal, pcInputVertical, enemiesPlaceHolder.transform, data.Player),
                new EnemyMoveController(enemies, player),
                new ShootController(pcInputFire, bulletFactory, data.BulletsData),
                new EnemySpawnController(enemies, enemyFactory, data, enemiesPlaceHolder.transform)
            };

            _executeControllers = controllers.ToArray();
        }

        public void Initialization()
        {
            foreach (var controller in _executeControllers)
            {
                (controller as IInitialization)?.Initialization();
            }
        }

        public void Cleanup()
        {
            foreach (var controller in _executeControllers)
            {
                (controller as ICleanup)?.Cleanup();
            }
        }
    }
}