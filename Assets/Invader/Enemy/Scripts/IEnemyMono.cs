using UnityEngine;

namespace Invader.Enemy
{
    public interface IEnemyMono
    {
        Transform Transform { get; }
        Vector2 GetPosition();
        void Move(Vector2 moveAmount);
    }
}