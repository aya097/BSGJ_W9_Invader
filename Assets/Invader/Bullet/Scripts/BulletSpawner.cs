using System;
using System.Collections;
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
        readonly Dictionary<BulletTarget, IEnumerable<Transform>> _targetTransforms;

        [Inject]
        public BulletSpawner(BulletMono bulletMono, IEnemyCluster enemyCluster, IEnumerable<ShelterMono> shelters, PlayerMono player)
        {
            _bulletPrefab = bulletMono;

            _targetTransforms.Add(BulletTarget.Enemy, enemyCluster.Enemies.Select(e => e.Transform));   // enemyの追加
            _targetTransforms.Add(BulletTarget.Shelter, shelters.Select(s => s.transform)); // Shelterの追加
            List<Transform> playerTransform = new() { player.transform };
            _targetTransforms.Add(BulletTarget.Player, playerTransform);    // Playerの追加
        }

        public void Spawn(Vector2 position, Vector2 direction, BulletTarget bulletTarget)
        {
            var bulletMono = GameObject.Instantiate(_bulletPrefab, position, Quaternion.identity);
            bulletMono.SetDirection(direction);

            List<Transform> targetTransforms = new();
            if (HasState(bulletTarget, BulletTarget.Enemy))
            {
                targetTransforms.AddRange(_targetTransforms[BulletTarget.Enemy]);
            }
            if (HasState(bulletTarget, BulletTarget.Shelter))
            {
                targetTransforms.AddRange(_targetTransforms[BulletTarget.Shelter]);
            }
            if (HasState(bulletTarget, BulletTarget.Player))
            {
                targetTransforms.AddRange(_targetTransforms[BulletTarget.Player]);
            }

            bulletMono.SetTarget(targetTransforms);
        }

        bool HasState(BulletTarget bulletTarget, BulletTarget state)
        {
            return (bulletTarget & state) == state;
        }
    }


}
