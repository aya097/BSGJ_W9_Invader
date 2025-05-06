#nullable enable

using VContainer;
using VContainer.Unity;

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
            _enemySpawner.Spawn();
        }
    }
}