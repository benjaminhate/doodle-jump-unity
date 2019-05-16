using System.Collections;
using Menu;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public Player player;
    
        public CameraFollow cameraFollow;
        public ScoreManager scoreManager;
        public MapGenerator mapGenerator;

        public ScoreUI scoreUi;
        public RestartMenu restartMenu;
        
        private Vector3 _basePlayerPosition;
    
        // Start is called before the first frame update
        private void Start()
        {
            _basePlayerPosition = player.transform.position;
            
            player.OnDeath += GameOver;
            Restart();
        }

        private void GameOver()
        {
            StartCoroutine(GameOverCoroutine());
        }

        private IEnumerator GameOverCoroutine()
        {
            player.gameObject.SetActive(false);
            mapGenerator.DeletePlatforms();
            yield return new WaitForEndOfFrame();
            restartMenu.Open();
            scoreUi.Close();
        }

        public void Restart()
        {
            restartMenu.Close();
            scoreUi.Open();
            
            player.transform.position = _basePlayerPosition;
            player.gameObject.SetActive(true);

            scoreManager.ResetScore();
            cameraFollow.ResetCamera();
            mapGenerator.ResetMap();
        }
    }
}
