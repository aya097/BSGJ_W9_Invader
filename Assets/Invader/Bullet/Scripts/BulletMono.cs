using UnityEngine;

namespace Invader.Bullet
{
    public class BulletMono : MonoBehaviour
    {
        public float speed = 10f;
        private Transform target;

        public void SetTarget(Transform targetTransform)
        {
            target = targetTransform;
        }

        public void Hit()
        {
            if (target.TryGetComponent<IOnHit>(out var hitComponent))
            {
                hitComponent.OnHit();
            }

            Destroy(gameObject);
        }

        void Update()
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            // 当たり判定（例: Raycastなど）でHit()を呼び出す処理を書くことが多いです
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            Hit();  // コリジョンを使う場合
        }
    }


}
