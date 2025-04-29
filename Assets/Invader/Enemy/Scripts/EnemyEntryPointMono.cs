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

        private EnemySpawner _enemySpawner = null!;
        private EnemyCluster _enemyCluster = null!;
        void Awake()
        {
            _enemyCluster = new EnemyCluster();
            _enemySpawner = new EnemySpawner(enemyMonoPrefab, _enemyCluster);
        }
    }
}