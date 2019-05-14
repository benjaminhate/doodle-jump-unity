using UnityEngine;

namespace Platforms
{
    public class Spring : BasePlatform
    {
        public Sprite jumpSprite;
        private SpriteRenderer _renderer;
    
        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        protected override bool Jump(Collider2D other)
        { 
            var hasJumped = base.Jump(other);

            if (!hasJumped) return false;
        
            _renderer.sprite = jumpSprite;
            GetComponent<Collider2D>().enabled = false;
            return true;
        }
    }
}
