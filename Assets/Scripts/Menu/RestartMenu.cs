using Game;
using TMPro;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class RestartMenu : MonoBehaviour
    {
        public GameManager gameManager;
        public FloatReference playerScore;
        public TMP_Text highscoreText;
        
        public void Open()
        {
            gameObject.SetActive(true);
            UpdateHighscoreText();
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private void UpdateHighscoreText()
        {
            highscoreText.text = $"Score : {playerScore.Value : 0}";
        }
        
        public void OnRestartPressed()
        {
            gameManager.Restart();
        }

        public void OnMenuPressed()
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }
    }
}
