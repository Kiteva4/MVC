using UnityEngine;

namespace MVCExample
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private Data _data;
        private Controllers _controllers;

        private void OnEnable()
        {
            // Debug.Log("OnEnable");
            _controllers = new Controllers(_data);
            _controllers.Initialization();
        }

        private void OnDisable()
        {
            _controllers.Cleanup();
        }

        private void Update()
        {
            // Debug.Log("SetActive");
            // gameObject.SetActive(true);
            var deltaTime = Time.deltaTime;
            for (var i = 0; i < _controllers.Length; i++)
            {
                _controllers[i].Execute(deltaTime);
            }
        }
    }
}
