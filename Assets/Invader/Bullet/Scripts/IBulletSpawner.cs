using System.Collections.Generic;
using UnityEngine;

namespace Invader.Bullet
{
    public interface IBulletSpawner
    {
        void Spawn(Vector2 position, Vector2 direction);
    }

}