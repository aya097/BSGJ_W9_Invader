using UnityEngine;
using TMPro;

namespace Invader.Score
{
    using R3;
    using UnityEngine.UI;
    using VContainer;

    public class ScoreViewMono : MonoBehaviour
    {
        [SerializeField] TMP_Text scoreText;

        [Inject]
        public void Initialize(ScoreNumber scoreNumber)
        {
            Observable.EveryValueChanged(scoreNumber, s => s.ScoreNum)
            .Subscribe(scoreNum =>
            {
                scoreText.text = "Score: " + scoreNum;

            });
        }
    }

}