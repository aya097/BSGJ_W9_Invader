# nullable enable
using UnityEngine;
using Invader.Bullet;

namespace Invader.Player
{
    /// <summary>
    /// Playerのメインとなるクラス
    /// </summary>
    public class PlayerMono : MonoBehaviour, IOnHit
    {
        private PlayerMover _playerMover = null!;
        private PlayerAttacker _playerAttacker = null!;

        [Header("PlayerMonoのパラメータ")]
        [SerializeField] int moveSpeed = 5;  // 移動速度

        void Awake()
        {
            _playerMover = new PlayerMover(moveSpeed, transform);
            _playerAttacker = new PlayerAttacker(); 
        }

        void Update()
        {
            // 左右の入力を取得
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f).normalized;
            Move(moveDirection);
            
            // スペースキーが押されたら攻撃
            if (Input.GetKeyDown(KeyCode.Space))  
            {
                Attack();
            }
        }

        public void OnHit()
        {
            Debug.Log("Player has been hit!"); //仮の被弾処理
        }

        public void Attack()
        {
            _playerAttacker.Attack();  // PlayerMonoの攻撃を実行
        }

        public void Move(Vector3 direction)
        {
            _playerMover.Move(direction);  // PlayerMonoの移動を実行
        }
    }
}
