#nullable enable
using UnityEngine;
using System.Linq;
using Invader.Utility;
using System;
using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine.UIElements;
using VContainer;

namespace Invader.Enemy
{
    enum EnemyMoveState
    {
        None,
        Right,   // 右
        Left,   // 左
        Forward,    // 前進
    }

    // Enemyの座標のラッパー
    class EnemiesPosition
    {
        private Vector2 _position;

        public EnemiesPosition(Vector2 init)
        {
            _position = init;
        }

        public Vector2 Get()
        {
            return _position;
        }

        public void Move(Vector2 moveAmount, IEnumerable<IEnemyMono> enemies)
        {
            _position += moveAmount;    // 座標を更新
            foreach (var enemy in enemies)
            {
                enemy.Move(moveAmount);
            }
        }
    }


    /// <summary>
    /// Enemy全体の動きに関するクラス
    /// </summary>
    public class EnemyMover
    {
        const float _speed = 3;
        const float _movingForwardAmount = 0.5f;

        private EnemyMoveState _currentMoveState;   // 現在の移動状態

        private Func<Vector2, bool> _isForwardFinished = (vec) => { return true; };    // 前進が終了するか確認する
        private Action? _onForwardFinished;  // 前進が終了した時のコールバック
        readonly IEnemyCluster _enemyCluster;
        readonly EnemiesPosition _enemiesPosition;

        [Inject]
        public EnemyMover(IEnemyCluster enemyCluster)
        {
            _currentMoveState = EnemyMoveState.Right;    // 最初は右移動
            _enemyCluster = enemyCluster;
            _enemiesPosition = new(Vector2.zero);
        }

        public void Move(float deltaTime)
        {
            // 左右移動の場合
            if (IsSideMovement(_currentMoveState))
            {
                // 端に到達したら
                if (IsReachEdge(_currentMoveState))
                {
                    ChangeMoveStateForward();   // 前進処理に変更
                }
            }
            // 前進の場合
            if (_currentMoveState == EnemyMoveState.Forward)
            {
                // 終了していれば終了処理
                if (_isForwardFinished.Invoke(_enemiesPosition.Get()))
                {
                    _onForwardFinished?.Invoke();
                }
            }

            Vector2 moveAmount = GetDirection(_currentMoveState) * _speed * deltaTime;
            _enemiesPosition.Move(moveAmount, _enemyCluster.Enemies);
        }

        // 移動状態に応じて移動方向を返す
        Vector2 GetDirection(EnemyMoveState moveState)
        {
            if (moveState == EnemyMoveState.None) Debug.LogWarning($"MoveState is None");

            if (moveState == EnemyMoveState.Right) return Vector2.right;
            else if (moveState == EnemyMoveState.Left) return Vector2.left;
            else if (moveState == EnemyMoveState.Forward) return Vector2.down;

            return Vector2.zero;
        }

        // 前進するときの処理
        void ChangeMoveStateForward()
        {
            EnemyMoveState currentMoveState = _currentMoveState;    // 現在のMoveStateのバッファ
            Vector2 targetPosition = _enemiesPosition.Get() + Vector2.down * _movingForwardAmount;

            _isForwardFinished = (currentPosition) =>
            {
                // 現在のy座標が目標座標よりも下にいればtrue
                return currentPosition.y < targetPosition.y;
            };
            _onForwardFinished = () =>
            {
                _currentMoveState = GetFlippedLR(currentMoveState);
            };

            _currentMoveState = EnemyMoveState.Forward;
        }

        // MoveStateに応じて端判定を行う
        bool IsReachEdge(EnemyMoveState moveState)
        {
            if (moveState == EnemyMoveState.None) Debug.Log($"MoveState is None");


            // x座標小さい順にEnemiesをソート
            var orderedEnemies = _enemyCluster.Enemies.OrderBy(enemy => enemy.GetPosition().x);
            float leftPositionX = orderedEnemies.FirstOrDefault().GetPosition().x;  // もっとも左の座標
            float rightPositionX = orderedEnemies.LastOrDefault().GetPosition().x;  // もっとも右の座標

            if (moveState == EnemyMoveState.Right)
            {
                var rightEdge = ScreenInfo.GetPositionByScreen(new Vector2(1, 0));
                return rightPositionX > rightEdge.x;
            }
            else if (moveState == EnemyMoveState.Left)
            {
                var leftEdge = ScreenInfo.GetPositionByScreen(new Vector2(0, 0));
                return leftPositionX < leftEdge.x;
            }

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