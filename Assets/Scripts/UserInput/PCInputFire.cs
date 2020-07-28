using System;
using UnityEngine;

namespace MVCExample
{
    public sealed class PCInputFire : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate (float f) { };

        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(AxisManager.FIRE1));
        }
    }
}