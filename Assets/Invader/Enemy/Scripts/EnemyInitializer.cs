#nullable enable

using VContainer;
using VContainer.Unity;
using R3;
using System.Threading;
using System;

namespace Invader.Enemy
{
    public class EnemyInitializer : IStartable
    {
        readonly EnemySpawner _enemySpawner;
        readonly EnemyMover _enemyMover;

        [Inject]
        public EnemyInitializer(EnemySpawner enemySpawner, EnemyMover enemyMover)
        {
            _enemySpawner = enemySpawner;
            _enemyMover = enemyMover;
        }

        void IStartable.Start()
        {
            // Enemy生成
            _enemySpawner.Spawn();

            float deltaTime = 0.2f;
            // Enemy移動
            Observable.Interval(TimeSpan.FromSeconds(deltaTime)).Subscribe(_ =>
            {
                _enemyMover.Move(deltaTime);
            });
        }
    }
}