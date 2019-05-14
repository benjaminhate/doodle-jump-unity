using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public delegate void DeathEvent();

    public delegate void JumpEvent();

    public event DeathEvent OnDeath;
    public event JumpEvent OnJump;
    
    public float movementSpeed = 10;

    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite leftJumpingSprite;
    public Sprite rightJumpingSprite;
    
    private float _jumpSpeed;

    public bool CanJump => _rb.velocity.y <= 0f;
    private bool IsFacingRight => _rb.velocity.x > 0f;
    private bool IsFacingLeft => _rb.velocity.x < 0f;

    private float _movement;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    private Sprite _movingSprite;
    private Sprite _jumpingSprite;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _movingSprite = rightSprite;
        _jumpingSprite = rightJumpingSprite;
    }

    private void Update()
    {
        _movement = Input.GetAxis("Horizontal") * movementSpeed;
    }

    private void FixedUpdate()
    {
        Move(_movement);
        ChangeSprite();
    }

    private void Move(float xForce)
    {
        var velocity = _rb.velocity;
        velocity.x = xForce;
        _rb.velocity = velocity;
    }

    private void ChangeSprite()
    {
        _movingSprite = IsFacingRight ? rightSprite : IsFacingLeft ? leftSprite : _movingSprite;
        _jumpingSprite = IsFacingRight ? rightJumpingSprite : IsFacingLeft ? leftJumpingSprite : _jumpingSprite;

        _spriteRenderer.sprite = CanJump ? _movingSprite : _jumpingSprite;;
    }

    public void Jump(float force)
    {
        var velocity = _rb.velocity;
        velocity.y = force;
        _rb.velocity = velocity;
        
        OnJump?.Invoke();
    }

    public void Death()
    {
        OnDeath?.Invoke();
    }
}
