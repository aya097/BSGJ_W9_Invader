#nullable enable
using UnityEngine;
using System.Linq;

namespace Invader.Enemy
{
    enum EnemyMoveState
    {
        None,
        Right,   // 右
        Left,   // 左
        Forward,    // 前進
    }

    /// <summary>
    /// Enemy全体の動きに関するクラス
    /// </summary>
    public class EnemyMover
    {
        const float _speed = 5;

        private EnemyMoveState _currentMoveState;
        readonly IEnemyCluster _enemyCluster;

        public EnemyMover(IEnemyCluster enemyCluster)
        {
            _currentMoveState = EnemyMoveState.Right;    // 最初は右移動
            _enemyCluster = enemyCluster;
        }


        public void Move(float deltaTime)
        {
            // 左右移動の場合
            if (IsSideMovement(_currentMoveState))
            {
                // 端に到達したら
                if (IsReachEdge(_currentMoveState))
                {
                    _currentMoveState = GetFlippedLR(_currentMoveState);    // 左右反転
                }
                Vector2 moveAmount = GetDirection(_currentMoveState) * _speed * deltaTime;
                MoveAll(moveAmount);
            }
        }

        Vector2 GetDirection(EnemyMoveState moveState)
        {
            if (moveState == EnemyMoveState.None) Debug.LogWarning($"MoveState is None");

            if (moveState == EnemyMoveState.Right) return Vector2.right;
            else if (moveState == EnemyMoveState.Left) return Vector2.left;
            else if (moveState == EnemyMoveState.Forward) return Vector2.down;

            return Vector2.zero;
        }

        void MoveAll(Vector2 moveAmount)
        {
            foreach (var enemy in _enemyCluster.Enemies)
            {
                enemy.Move(moveAmount);
            }
        }

        // MoveStateに応じて端判定を行う
        bool IsReachEdge(EnemyMoveState moveState)
        {
            if (moveState == EnemyMoveState.None) Debug.Log($"MoveState is None");


            // x座標小さい順にEnemiesをソート
            var orderedEnemies = _enemyCluster.Enemies.OrderBy(enemy => enemy.GetPosition().x);
            float leftPositionX = orderedEnemies.FirstOrDefault().GetPosition().x;  // もっとも左の座標
            float rightPositionX = orderedEnemies.LastOrDefault().GetPosition().x;  // もっとも右の座標


            return false;
        }

        // 左右移動か判定
        bool IsSideMovement(EnemyMoveState moveState)
        {
            if (moveState == EnemyMoveState.None) Debug.Log($"MoveState is None");


            bool IsSide = moveState == EnemyMoveState.Right || moveState == EnemyMoveState.Left;
            return IsSide;
        }

        // 右と左を入れ替える
        EnemyMoveState GetFlippedLR(EnemyMoveState moveState)
        {
            if (moveState == EnemyMoveState.Right) return EnemyMoveState.Left;
            else if (moveState == EnemyMoveState.Left) return EnemyMoveState.Right;

            Debug.LogWarning($"MoveState is None");
            return EnemyMoveState.None;
        }
    }
}