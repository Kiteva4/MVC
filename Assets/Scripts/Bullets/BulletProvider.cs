using System;
using UnityEngine;

namespace MVCExample
{
    public class BulletProvider : MonoBehaviour, IBullet
    {
        private readonly Vector2 _moveDirection;
        private void OnEnable()
        {
            Debug.Log($"Bullet enabled, target is {Input.mousePosition},");
        }

        private void OnDisable()
        {
            throw new NotImplementedException();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            throw new NotImplementedException();
        }
    }
}