#nullable enable

using UnityEngine;
using System.Linq;
using Invader.Bullet;

namespace Invader.Enemy
{
    public class EnemyAttacker
    {
        readonly IEnemyCluster _enemyCluster;
        readonly IBulletSpawner _bulletSpawner;

        public EnemyAttacker(IEnemyCluster enemyCluster, IBulletSpawner bulletSpawner)
        {
            _enemyCluster = enemyCluster;
            _bulletSpawner = bulletSpawner;
        }

        public void Attack()
        {
            var enemies = _enemyCluster.Enemies;
            int randomIndex = Random.Range(0, enemies.Count());
            var position = enemies.ElementAt(randomIndex).GetPosition();    // ランダムなEnemyの座標を取得
            _bulletSpawner.Spawn();
        }
    }
}