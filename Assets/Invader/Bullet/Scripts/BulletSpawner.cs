using UnityEngine;

namespace Invader.Bullet
{
    public class BulletSpawner : IBulletSpawner
    {
        private BulletMono bulletPrefab;


        public void Spawn(Vector2 position, Vector2 direction)
        {
            var bulletMono = GameObject.Instantiate(bulletPrefab, position, Quaternion.identity);
            bulletMono.SetDirection(direction);
        }
    }


}
