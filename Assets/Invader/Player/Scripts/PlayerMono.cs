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
        //俺が追加した
        [Header("Bullet")]
        [SerializeField] private BulletSpawner? _bulletSpawner = null;
        //追加


        void Awake()
        {

            _playerMover = new PlayerMover(moveSpeed, transform);
            _playerAttacker = new PlayerAttacker();
            //追加ここから
            _bulletSpawner = GetComponent<BulletSpawner>(); // Awakeで取得
            if (_bulletSpawner == null)
            {
                Debug.LogError("BulletSpawnerコンポーネントが見つかりません！");
            }



            //追加ここまで
        }
        //追加ここから
        private IBulletSpawner bulletSpawner;

        void Start()
        {
            // BulletSpawnerコンポーネントを取得
            bulletSpawner = GetComponent<IBulletSpawner>();

            if (bulletSpawner == null)
            {
                Debug.LogError("BulletSpawnerコンポーネントが見つかりません！");
            }
        }
        //追加ここまで

        void Update()
        {
            // 左右の入力を取得
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f).normalized;
            Move(moveDirection);

            // スペースキーが押されたら攻撃
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Attack();俺がコメントアウト
                bulletSpawner.Spawn();//追加
            }
        }

        public void OnHit()
        {
            Debug.Log("Player has been hit!"); //仮の被弾処理
        }

        public void Attack()
        {
            if (_bulletSpawner != null)
            {
                _playerAttacker.Attack(_bulletSpawner);  // 安全に呼び出し
            }
            else
            {
                Debug.LogError("Attackに必要なBulletSpawnerが設定されていません。");
            }


            // _playerAttacker.Attack(_bulletSpawner);  // PlayerMonoの攻撃を実行


            //()中は追加

        }

        public void Move(Vector3 direction)
        {
            _playerMover.Move(direction);  // PlayerMonoの移動を実行
        }
    }
}
