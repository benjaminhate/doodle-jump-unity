using UnityEngine;

namespace Game
{
    public class MapUnloader : MonoBehaviour
    {
        public Transform platformParent;
        public Player player;
        public float unloadDistance = 10f;
    
        private void Start()
        {
            player.OnJump += Unload;
        }

        private void Unload()
        {
            var playerPos = player.transform.position;

            foreach (Transform platform in platformParent)
            {
                if (platform.position.y < playerPos.y - unloadDistance)
                {
                    Destroy(platform.gameObject);
                }
            }
        }
    }
}
