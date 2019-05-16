using Game;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public TMP_Text highscoreText;
    
        private void Start()
        {
            UpdateHighscoreText();
        }

        private void UpdateHighscoreText()
        {
            var score = PlayerPrefs.GetFloat(ScoreManager.ScorePrefs);
            highscoreText.text = $"Highscore : {score : 0}";
        }

        public void OnPlayPressed()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        }
    
    
    }
}
