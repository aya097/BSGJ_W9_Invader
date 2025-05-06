using System;
using System.Collections.Generic;
using System.Linq;
using Invader.Enemy;
using Invader.Player;
using Invader.Shelter;
using UnityEngine;
using VContainer;

namespace Invader.Bullet
{
    // Targetのフラグ
    [Flags]
    public enum BulletTarget
    {
        None = 0,
        Enemy = 1 << 0,
        Player = 1 << 1,
        Shelter = 1 << 2,

    }
    public class BulletSpawner : IBulletSpawner
    {
        readonly BulletMono _bulletPrefab;
        readonly IEnemyCluster _enemyCluster;
        readonly IEnumerable<ShelterMono> _shelters;



        [Inject]
        public BulletSpawner(BulletMono bulletMono, IEnemyCluster enemyCluster, IEnumerable<ShelterMono> shelters)
        {
            _bulletPrefab = bulletMono;
            _enemyCluster = enemyCluster;
            _shelters = shelters;
        }

        public void Spawn(Vector2 position, Vector2 direction, BulletTarget bulletTarget)
        {
            var bulletMono = GameObject.Instantiate(_bulletPrefab, position, Quaternion.identity);
            bulletMono.SetDirection(direction);

            List<Transform> targetTransforms = new();
            if (HasState(bulletTarget, BulletTarget.Enemy))
            {
                targetTransforms.AddRange(_enemyCluster.Enemies.Select(e => e.Transform));
            }
            if (HasState(bulletTarget, BulletTarget.Shelter))
            {
                targetTransforms.AddRange(_shelters.Where(s => s != null).Select(s => s.transform));
            }
            if (HasState(bulletTarget, BulletTarget.Player))
            {
                var player = GameObject.FindObjectsByType<PlayerMono>(FindObjectsSortMode.None);

                List<Transform> playerTransforms = new() { player.First().transform };
                targetTransforms.AddRange(playerTransforms);
            }

            bulletMono.SetTarget(targetTransforms);
        }

        bool HasState(BulletTarget bulletTarget, BulletTarget state)
        {
            return (bulletTarget & state) == state;
        }
    }


}
