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

        public void OnHit()
        {
            OnDied?.Invoke(this, EventArgs.Empty);  // ヒット＝死
        }
    }
}