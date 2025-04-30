#nullable enable
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
    }
}