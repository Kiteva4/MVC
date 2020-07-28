using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MVCExample
{
    public sealed class ShootController : IExecute, ICleanup
    {
        private float _fire;
        private IUserInputProxy _fireInputProxy;

        public ShootController(IUserInputProxy fire)
        {
            _fireInputProxy = fire;

            _fireInputProxy.AxisOnChange += FireOnAxisOnChange;
        }

        void FireOnAxisOnChange(float value)
        {
            _fire = value;
        }

        public void Execute(float deltaTime)
        {
            if(_fire == 1)
            {
                
            }
        }

        public void Cleanup()
        {
            _fireInputProxy.AxisOnChange -= FireOnAxisOnChange;
        }
    }
}