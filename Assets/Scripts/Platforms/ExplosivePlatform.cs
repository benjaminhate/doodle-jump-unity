using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Platforms
{
    public class ExplosivePlatform : BasePlatform
    {
        public float autoDestructTime;
        public Color baseColor;
        public Color finalColor;
        
        private SpriteRenderer _spriteRenderer;
        
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = baseColor;
        }

        protected override bool Jump(Collider2D other)
        {
            var hasJumped = base.Jump(other);

            StartCoroutine(AutoDestruct());
            
            return hasJumped;
        }

        private IEnumerator AutoDestruct()
        {
            var startTime = Time.time;
            var time = 0f;
            while (time < autoDestructTime)
            {
                time = Time.time - startTime;
                var percent = time / autoDestructTime;
                var color = Color.Lerp(baseColor, finalColor, percent);
                _spriteRenderer.color = color;
                
                yield return null;
            }
            Destroy(gameObject);
        }
    }
}
