#nullable enable

using Unity.Mathematics;
using UnityEngine;

namespace Invader.Enemy
{
    /// <summary>
    /// EnemyMonoを生成するクラス
    /// </summary>
    public class EnemySpawner
    {
        readonly IEnemyCluster _enemyCluster;   // 作成したEnemyMonoを集約する
        readonly GameObject _enemyMonoPrefab;   // EnemyMonoのPrefabを受け取る

        public EnemySpawner(GameObject enemyMonoPrefab, EnemyCluster enemyCluster)
        {
            _enemyMonoPrefab = enemyMonoPrefab;
            _enemyCluster = enemyCluster;

            SpawnEnemy(new Vector3(0, 0));  // 仮生成
        }

        void SpawnEnemy(Vector3 position)
        {
            var enemyMono = UnityEngine.GameObject.Instantiate(_enemyMonoPrefab, position, quaternion.identity);    // 引数の座標にEnemyを生成
        }
    }
}