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
        const int _rowNum = 4;
        const int _columnNum = 8;
        readonly Vector2 _distance = new Vector2(1.5f, 1.5f);
        readonly Vector2 _leftTop = new Vector2(-6f, 4f);

        readonly IEnemyCluster _enemyCluster;   // 作成したEnemyMonoを集約する


        public EnemySpawner(GameObject enemyMonoPrefab, EnemyCluster enemyCluster)
        {
            _enemyCluster = enemyCluster;
            SpawnEnemyArranged(enemyMonoPrefab, _leftTop, _rowNum, _columnNum, _distance);
        }

        void SpawnEnemyArranged(GameObject enemyMonoPrefab, Vector2 leftTopPosition, int rowNum, int columnNum, Vector2 distance)
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
        void SpawnEnemy(GameObject enemyMonoPrefab, Vector2 position)
        {
            var enemyObject = GameObject.Instantiate(enemyMonoPrefab, position, quaternion.identity);    // 引数の座標にEnemyを生成
            IEnemyMono enemyMono = enemyObject.GetComponent<EnemyMono>();   // EnemyMonoをインタフェースで取得する
            _enemyCluster.AddEnemy(enemyMono);
        }
    }
}