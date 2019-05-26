using UnityEngine;

namespace Game
{
    public class MapUnloader : MonoBehaviour
    {
        public Transform platformParent;
        public Transform player;
        public float unloadDistance = 10f;

        public void Unload()
        {
            var playerPos = player.position;

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
