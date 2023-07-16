using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideScroller : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _jumpForce = 200f;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");

        transform.Translate(new Vector2(horizontal, 0f) * Time.deltaTime * _moveSpeed);

        if (horizontal < 0f)
            _spriteRenderer.flipX = true;
        else if (horizontal > 0f)
            _spriteRenderer.flipX = false;
        if (Input.GetButtonDown("Jump"))
            _rb.AddForce(Vector2.up * _jumpForce);
    }

    void FixedUpdate()
    {
       
    }
}