# nullable enable
using Invader.Bullet;
using UnityEngine;
using VContainer;

namespace Invader.Player
{
    /// <summary>
    /// PlayerMonoの攻撃を実行するクラス
    /// </summary>
    public class PlayerAttacker
    {
        readonly IBulletSpawner _bulletSpawner;
        [Inject]
        public PlayerAttacker(IBulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;
        }
        public void Attack(Vector2 position)
        {
            var target = BulletTarget.Enemy | BulletTarget.Shelter;
            _bulletSpawner.Spawn(position, Vector2.up, target);
        }
    }
}