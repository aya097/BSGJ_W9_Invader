#nullable enable

using Unity.Mathematics;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Invader.Enemy
{
    /// <summary>
    /// EnemyMonoを生成するクラス
    /// </summary>
    public class EnemySpawner
    {
        readonly IEnemyCluster _enemyCluster;   // 作成したEnemyMonoを集約する
        readonly EnemyParamServer _enemyParamServer;
        readonly EnemyMono _enemyMonoPrefab;

        [Inject]
        public EnemySpawner(EnemyParamServer enemyParamServer, EnemyMono enemyMonoPrefab, IEnemyCluster enemyCluster)
        {
            _enemyParamServer = enemyParamServer;
            _enemyCluster = enemyCluster;
            _enemyMonoPrefab = enemyMonoPrefab;
        }

        public void Spawn()
        {
            SpawnEnemyArranged(_enemyMonoPrefab, _enemyParamServer.GetLeftTop(), _enemyParamServer.GetRowNum(), _enemyParamServer.GetColumnNum(), _enemyParamServer.GetDistance());
        }

        void SpawnEnemyArranged(EnemyMono enemyMonoPrefab, Vector2 leftTopPosition, int rowNum, int columnNum, Vector2 distance)
        {
            for (int row = 0; row < rowNum; row++)  // 行繰り返し
            {
                for (int col = 0; col < columnNum; col++)   // 列繰り返し
                {
                    Vector2 position = leftTopPosition + distance * new Vector2(col, -row);  // 行列分離れた座標
                    SpawnEnemy(enemyMonoPrefab, position);
                }
            }
        }
        void SpawnEnemy(EnemyMono enemyMonoPrefab, Vector2 position)
        {
            var enemyObject = GameObject.Instantiate(enemyMonoPrefab, position, quaternion.identity);    // 引数の座標にEnemyを生成
            IEnemyMono enemyMono = enemyObject.GetComponent<EnemyMono>();   // EnemyMonoをインタフェースで取得する
            _enemyCluster.AddEnemy(enemyMono);
        }
    }
}