#nullable enable
using System;
using Invader.Bullet;
using UnityEngine;

namespace Invader.Enemy
{
    /// <summary>
    /// Enemyのメインとなるクラス
    /// </summary>
    public class EnemyMono : MonoBehaviour, IEnemyMono, IOnHit
    {
        public event EventHandler? OnDied;  // null許容

        public Vector2 GetPosition()
        {
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            return position;
        }
        public void Move(Vector2 moveAmount)
        {
            Vector3 amount = new Vector3(moveAmount.x, moveAmount.y, 0);
            transform.Translate(amount);
        }
        public void OnHit()
        {
            OnDied?.Invoke(this, EventArgs.Empty);  // ヒット＝死
        }
    }
}