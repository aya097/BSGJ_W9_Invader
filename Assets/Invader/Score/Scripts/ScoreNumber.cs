using UnityEngine;

namespace Invader.Score
{
    public class ScoreNumber
    {
        public int ScoreNum { get; private set; } = 0;

        public void Increase(int amount)
        {
            ScoreNum += amount;
        }
    }

}