using Game;
using Tools;
using UnityEngine;

namespace Platforms
{
    public class BasePlatform : MonoBehaviour
    {
        public FloatReference jumpForce;
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            Jump(other.collider);
        }

        protected virtual bool Jump(Collider2D other)
        {
            if (!other.CompareTag("PlayerFeet")) return false;
        
            var player = other.transform.root.GetComponent<Player>();
            if (player == null) return false;

            var canJump = player.CanJump;
            if(canJump) player.Jump(jumpForce);
            return canJump;
        }
    }
}
