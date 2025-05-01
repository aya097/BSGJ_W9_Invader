#nullable enable
using UnityEngine;

namespace Invader.Enemy
{
    /// <summary>
    /// Enemyに関する値を集めて、提供するクラス
    /// </summary>
    public class EnemyParamServer
    {
        readonly EnemySpawnerParam _enemySpawnerParam;

        public EnemyParamServer(EnemySpawnerParam enemySpawnerParam)
        {
            _enemySpawnerParam = enemySpawnerParam;
        }

        public int GetRowNum()
        {
            return _enemySpawnerParam.rowNum;
        }

        public int GetColumnNum()
        {
            return _enemySpawnerParam.columnNum;
        }

        public Vector2 GetDistance()
        {
            return _enemySpawnerParam.distance;
        }

        public Vector2 GetLeftTop()
        {
            return _enemySpawnerParam.leftTop;
        }
    }
}