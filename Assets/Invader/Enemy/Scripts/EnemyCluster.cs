#nullable enable

using System.Collections.Generic;

namespace Invader.Enemy
{
    /// <summary>
    /// EnemyMonoを集約したクラス
    /// </summary>
    public class EnemyCluster : IEnemyCluster
    {
        public IEnumerable<IEnemyMono> Enemies => _enemies; // EnemyMonoへの参照
        readonly List<IEnemyMono> _enemies = new();

        public void AddEnemy(IEnemyMono enemy)
        {
            _enemies.Add(enemy);
        }
        public void RemoveEnemy(IEnemyMono enemy)
        {
            _enemies.Remove(enemy);
        }
    }
}