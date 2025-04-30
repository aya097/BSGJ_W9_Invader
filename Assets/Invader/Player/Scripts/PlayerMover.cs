#nullable enable
using UnityEngine;

namespace Invader.Player
{
    /// <summary>
    /// PlayerMonoの移動を実行するクラス
    /// </summary>
    public class PlayerMover
    {
        private readonly float _moveSpeed;  
        private readonly Transform _playerTransform;  

        public PlayerMover(float moveSpeed, Transform playerTransform)
        {
            _moveSpeed = moveSpeed;
            _playerTransform = playerTransform;
        }


        public void Move(Vector3 direction)
        {
            _playerTransform.Translate(direction * _moveSpeed * Time.deltaTime); 
        }
    }
}