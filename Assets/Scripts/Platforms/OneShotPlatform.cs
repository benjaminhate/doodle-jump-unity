using UnityEngine;

namespace Platforms
{
    public class OneShotPlatform : BasePlatform
    {
        protected override bool Jump(Collider2D other)
        {
            var hasJumped = base.Jump(other);

            if (hasJumped) Destroy(gameObject);
        
            return hasJumped;
        }
    }
}
