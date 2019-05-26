using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class PauseMenu : MonoBehaviour
    {
        public Canvas pauseCanvas;

        private bool IsPaused { get; set; }
    
        private void Start()
        {
            Resume();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        private void Pause()
        {
            Time.timeScale = 0f;
            pauseCanvas.enabled = true;
            IsPaused = true;
        }

        private void Resume()
        {
            Time.timeScale = 1f;
            pauseCanvas.enabled = false;
            IsPaused = false;
        }

        public void OnResumePressed()
        {
            Resume();
        }

        public void OnMenuPressed()
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }
    }
}
