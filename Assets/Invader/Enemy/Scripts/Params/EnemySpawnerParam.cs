using UnityEngine;

namespace Invader.Enemy
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemySpawnerParam")]
    public class EnemySpawnerParam : ScriptableObject
    {
        [Header("行数（縦の数）")]
        [SerializeField] public int rowNum;

        [Header("列数（横の数）")]
        [SerializeField] public int columnNum;

        [Header("敵同士の距離")]
        [SerializeField] public Vector2 distance;

        [Header("生成開始（左上）")]
        [SerializeField] public Vector2 leftTop;
    }
}