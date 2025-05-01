# nullable enable
using Invader.Bullet;
using UnityEngine;

namespace Invader.Player
{
    /// <summary>
    /// PlayerMonoの攻撃を実行するクラス
    /// </summary>
    public class PlayerAttacker
    {
        public void Attack(BulletSpawner bulletSpawner)//()の中を追加
        {
            if (bulletSpawner != null)//追加
            {
                bulletSpawner.Spawn();

            }//追加

            Debug.Log("Player is attacking!");  // 仮の攻撃処理
        }
    }
}