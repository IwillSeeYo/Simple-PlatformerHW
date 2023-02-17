using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    private const string RunAnimation = "IsRun";
    private const string JumpAnimation = "IsJump";

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isGrounded;
    private float _groundRadius = 0.6f;
    private float _speed = 10f;
    private float _jumpForce = 10f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundMask);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;

            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetBool(RunAnimation, true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;

            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetBool(RunAnimation, true);
        }
        else
        {
            _animator.SetBool(RunAnimation, false);
        }
    }

    private void Jump()
    {
        _animator.SetBool(JumpAnimation, true);

        if (_isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x * Time.deltaTime, _jumpForce);
            }

            _animator.SetBool(JumpAnimation, false);
        }
    }
}