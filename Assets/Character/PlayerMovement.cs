using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _controllerTolerance = 0.05f;
    [SerializeField] float _jumpForce = 10f;

    private bool _isFalling = false;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private float _horizontal;

    private void Awake()
    {
        _animator = GetComponent<Animator>(); // needed for telling the animator to change values
        _spriteRenderer = GetComponent<SpriteRenderer>(); // needed for flipping sprite to face direction

    }

    void Update()
    {
        MovePlayer();
        FlipSprite();
        SetWalkAnimation();
        /*
        if (_isFalling )
        {
            _animator.SetBool("onAir", true);
        } else
        {
            _animator.SetBool("onAir", false);
        }

        */
    }



    private void MovePlayer()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 playerMovement = new Vector2(_horizontal, 0f).normalized;
        transform.Translate(playerMovement * Time.deltaTime * _moveSpeed);
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Jump"))
        {
            _animator.SetTrigger("jump");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // _isFalling = true;
        _animator.SetBool("onAir", true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // _isFalling = false;
        _animator.SetBool("onAir", false);
    }

    private void FlipSprite()
    {
        // flip the sprite to face the left when moving left
        if (_horizontal > 0)
            _spriteRenderer.flipX = false;

        // flip the sprite to face right when moving right
        if (_horizontal < 0)
            _spriteRenderer.flipX = true;
    }
    private void SetWalkAnimation()
    {
        if (Mathf.Abs(_horizontal) >= _controllerTolerance)
            _animator.SetBool("isRunning", true);
        if (Mathf.Abs(_horizontal) < _controllerTolerance)
            _animator.SetBool("isRunning", false);
    }
}
