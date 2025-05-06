using System.Collections.Generic;
using UnityEngine;

namespace Invader.Bullet
{
    public class BulletMono : MonoBehaviour
    {
        private float _speed = 10f;
        private Vector2 _direction = Vector2.zero;
        private float _collisionRadius = 0.5f;
        private IEnumerable<Transform> _targetTransforms;

        public void SetTarget(IEnumerable<Transform> targetTransforms)
        {
            _targetTransforms = targetTransforms;
        }
        public void SetDirection(Vector2 direction)
        {
            _direction = direction.normalized;
        }

        void Hit(Transform hitTransform)
        {
            if (hitTransform.TryGetComponent<IOnHit>(out var hitComponent))
            {
                hitComponent.OnHit();
            }

            Destroy(gameObject);
        }

        void Update()
        {
            transform.Translate(_direction * _speed * Time.deltaTime);

            foreach (Transform targetTransform in _targetTransforms)
            {
                if (targetTransform == null) continue;
                // 衝突半径以内にあれば衝突
                if ((targetTransform.position - transform.position).sqrMagnitude < Mathf.Pow(_collisionRadius, 2))
                {
                    Hit(targetTransform);
                    break;
                }
            }
        }
    }


}
