using UnityEngine;
using VContainer;

namespace Invader.Bullet
{
    public class BulletSpawner : IBulletSpawner
    {
        private BulletMono _bulletPrefab;

        [Inject]
        public BulletSpawner(BulletMono bulletMono)
        {
            _bulletPrefab = bulletMono;
        }

        public void Spawn(Vector2 position, Vector2 direction)
        {
            var bulletMono = GameObject.Instantiate(_bulletPrefab, position, Quaternion.identity);
            bulletMono.SetDirection(direction);
        }
    }


}
