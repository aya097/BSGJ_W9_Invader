using UnityEngine;

namespace Invader.Score
{
    public class ScoreNumber
    {
        public int scoreNum { get; private set; } = 0;

        public void Increase(int amount)
        {
            scoreNum += amount;
            Debug.Log($"Score increased to {scoreNum}");
        }
    }

}