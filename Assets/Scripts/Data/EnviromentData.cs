using UnityEngine;

namespace MVCExample
{
    [CreateAssetMenu(fileName = "EnviromentData", menuName = "Data/Unit/EnviromentData")]
    public sealed class EnviromentData : ScriptableObject
    {
        public GameObject spaceParticle;
    }
}
