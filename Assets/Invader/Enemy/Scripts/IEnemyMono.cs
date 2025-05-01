using UnityEngine;

namespace Invader.Enemy
{
    public interface IEnemyMono
    {
        Vector2 GetPosition();
        void Move(Vector2 moveAmount);
    }
}