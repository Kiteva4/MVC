using UnityEngine;

namespace MVCExample
{
    public sealed class EnemyProvider : MonoBehaviour, IEnemy
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _stopDistance;
        private Rigidbody2D _rigidbody2D;
        private Transform _transform;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = transform;
        }

        public void Move(Vector3 point)
        {
            if ((_transform.position - point).sqrMagnitude >= _stopDistance * _stopDistance)
            {
                var dir = (point - _transform.position).normalized;
                _rigidbody2D.velocity = dir * _speed;
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //TODO поменять на теги
            if (other.gameObject.name == "player")
            {
                other.gameObject.SetActive(false);
                // gameStateController set state to gameOver
            }
            else if (other.gameObject.name == "bullet")
            {
                //TODO add pull of enemy objects
                // scoreController incrementScore and destroy this enemy
            }
        }
    }
}
