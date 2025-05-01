using Invader.Bullet;
using UnityEngine;
using System.Linq;

namespace Invader.Shelter
{
    public class ShelterMono : MonoBehaviour, IOnHit
    {

        public void OnHit()
        {
            Transform[] shelterChildren = gameObject.GetComponentsInChildren<Transform>();

            // y座標が最大の子オブジェクトを取得（インベーダー側のシェルターから破壊）
            Transform maxYChild = shelterChildren
                .Where(child => child != transform) 
                .OrderByDescending(child => child.position.y) 
                .FirstOrDefault(); 

            if (maxYChild != null)
            {
                Destroy(maxYChild.gameObject);
            }

        }
    }
}
