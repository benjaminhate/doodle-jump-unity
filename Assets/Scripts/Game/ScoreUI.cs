using TMPro;
using Tools;
using UnityEngine;

namespace Game
{
    public class ScoreUI : MonoBehaviour
    {
        public TMP_Text scoreText;
        public FloatReference playerScore;

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
        
        private void Update()
        {
            UpdateTextScore();
        }
    
        private void UpdateTextScore()
        {
            scoreText.text = $"{playerScore.Value : 0}";
        }
    }
}
