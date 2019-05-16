using UnityEngine;

namespace Game
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // GAME OVER
                other.GetComponent<Player>()?.Death();
                Debug.Log("GAME OVER");
            }
        }
    }
}
