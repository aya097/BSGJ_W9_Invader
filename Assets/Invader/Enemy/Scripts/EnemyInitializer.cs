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
        readonly EnemyAttacker _enemyAttacker;

        [Inject]
        public EnemyInitializer(EnemySpawner enemySpawner, EnemyMover enemyMover, EnemyAttacker enemyAttacker)
        {
            _enemySpawner = enemySpawner;
            _enemyMover = enemyMover;
            _enemyAttacker = enemyAttacker;
        }

        void IStartable.Start()
        {
            // Enemy生成
            _enemySpawner.Spawn();

            // Enemy移動
            float moveDeltaTime = 0.1f;
            Observable.Interval(TimeSpan.FromSeconds(moveDeltaTime)).Subscribe(_ =>
            {
                _enemyMover.Move(moveDeltaTime);
            });

            // Enemy攻撃
            float attackDeltaTime = 1f;
            Observable.Interval(TimeSpan.FromSeconds(attackDeltaTime)).Subscribe(_ =>
            {
                _enemyAttacker.Attack();
            });

        }
    }
}