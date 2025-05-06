#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Invader.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] Enemy.EnemySpawnerParam _enemySpawnParam = null!;
        [SerializeField] Enemy.EnemyMono _enemyMonoPrefab = null!;
        [SerializeField] Bullet.BulletMono _bulletMonoPrefab = null!;
        protected override void Configure(IContainerBuilder builder)
        {
            // Enemy
            builder.Register<Enemy.EnemySpawner>(Lifetime.Scoped);
            builder.Register<Enemy.EnemyAttacker>(Lifetime.Scoped);
            builder.Register<Enemy.EnemyMover>(Lifetime.Scoped);
            builder.Register<Enemy.EnemyParamServer>(Lifetime.Scoped);
            builder.Register<Enemy.EnemyCluster>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.RegisterInstance(_enemySpawnParam);
            builder.RegisterInstance(_enemyMonoPrefab);

            // Player
            builder.Register<Player.PlayerAttacker>(Lifetime.Scoped);
            builder.RegisterComponentInHierarchy<Player.PlayerMono>();

            // Bullet
            builder.Register<Bullet.BulletSpawner>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.RegisterInstance(_bulletMonoPrefab);

            // Shelter
            var shelters = FindObjectsByType<Shelter.ShelterMono>(FindObjectsSortMode.None);
            builder.RegisterInstance<IEnumerable<Shelter.ShelterMono>>(shelters);


            // EntryPoint
            builder.RegisterEntryPoint<Enemy.EnemyInitializer>();
        }
    }
}