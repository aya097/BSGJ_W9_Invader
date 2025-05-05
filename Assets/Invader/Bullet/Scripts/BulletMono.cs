using System.Collections.Generic;
using UnityEngine;

namespace Invader.Bullet
{
    public class BulletMono : MonoBehaviour
    {
        private float _speed = 10f;
        private float _collisionRadius = 0.5f;
        private IEnumerable<Transform> _targetTransforms;

        public void SetTarget(IEnumerable<Transform> targetTransforms)
        {
            _targetTransforms = targetTransforms;
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
            transform.Translate(Vector3.up * _speed * Time.deltaTime);

            foreach (Transform targetTransform in _targetTransforms)
            {
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
