using UnityEngine;

namespace Invader.Score
{
    using UnityEngine.UI;

    public class ScoreViewMono : MonoBehaviour
    {
        public Text scoreText;
        public ScoreNumber score;

        void Update()
        {
            scoreText.text = "Score: " + score.scoreNum;
        }
    }

}