using System.Collections.Generic;

namespace Invader.Enemy
{
    public interface IEnemyCluster
    {
        IEnumerable<IEnemyMono> Enemies { get; }
        void AddEnemy(IEnemyMono enemy);
        void RemoveEnemy(IEnemyMono enemy);
    }
}