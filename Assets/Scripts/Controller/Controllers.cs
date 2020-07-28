using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public sealed class Controllers : IInitialization, ICleanup
    {
        public enum CONTROLLERS
        {
            InputController = 0,
            MoveController,
            EnemyMoveController,
            ShootController,
            EnemySpawnController,
            count,
        }

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

            CompositeMove enemies = new CompositeMove();

            _executeControllers = new IExecute[(int)CONTROLLERS.count];

            _executeControllers[(int)CONTROLLERS.InputController] = new InputController(pcInputHorizontal, pcInputVertical, pcInputFire);
            _executeControllers[(int)CONTROLLERS.MoveController] = new MoveController(pcInputHorizontal, pcInputVertical, enemiesPlaceHolder.transform, data.Player);
            _executeControllers[(int)CONTROLLERS.EnemyMoveController] = new EnemyMoveController(enemies, player);
            _executeControllers[(int)CONTROLLERS.ShootController] = new ShootController(pcInputFire);
            _executeControllers[(int)CONTROLLERS.EnemySpawnController] = new EnemySpawnController(enemies, data, enemiesPlaceHolder.transform);
        }

        public void Initialization()
        {
        }

        public void Cleanup()
        {
            (_executeControllers[(int)CONTROLLERS.MoveController] as ICleanup).Cleanup();
            (_executeControllers[(int)CONTROLLERS.ShootController] as ICleanup).Cleanup();
        }
    }
}
