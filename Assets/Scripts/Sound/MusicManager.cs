using UnityEngine;

namespace Sound
{
    public class MusicManager : MonoBehaviour
    {
        private static MusicManager _instance;
    
        public AudioSource source;
        public AudioClip music;
    
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            source.clip = music;
            source.Play();
        }
    }
}
