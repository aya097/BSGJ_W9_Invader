using UnityEngine;

namespace Invader.Bullet
{
    public class BulletSpawner : MonoBehaviour, IBulletSpawner
    {
        public BulletMono bulletPrefab;

        public void Spawn()
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }


}
