using UnityEngine;

namespace Invader.Bullet
{
    public class BulletSpawner : MonoBehaviour, IBulletSpawner
    {
        public GameObject bulletPrefab;

        public void Spawn()
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }


}
