#nullable enable
using UnityEngine;

namespace Invader.Enemy
{
    /// <summary>
    /// Enemyに関する処理のエントリーポイント
    /// </summary>
    public class EnemyEntryPointMono : MonoBehaviour
    {
        [SerializeField] GameObject enemyMonoPrefab = null!;
        [SerializeField] EnemySpawnerParam enemySpawnerParam = null!;

        private EnemySpawner _enemySpawner = null!;
        private EnemyCluster _enemyCluster = null!;
        private EnemyParamServer _enemyParamServer = null!;
        void Awake()
        {
            _enemyCluster = new EnemyCluster();
            _enemyParamServer = new EnemyParamServer(enemySpawnerParam);
            _enemySpawner = new EnemySpawner(_enemyParamServer, enemyMonoPrefab, _enemyCluster);
        }
    }
}