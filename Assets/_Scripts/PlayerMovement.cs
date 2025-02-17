using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 12.0f;
    public BoxCollider2D groundCollider;
    public SpriteRenderer sr;
    public Animator animator;

    private Rigidbody2D rb;
    private const float gravity = 2.0f;

    // Improvements to consider:
    // - Double jump
    // - Easing into movement (accelerating more slowly)

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        bool idle = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            sr.flipX = true;
            animator.Play("PlayerRun");
            idle = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            sr.flipX = false;
            animator.Play("PlayerRun");
            idle = false;
        }

        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                animator.Play("PlayerJump");
                rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                idle = false;
            }
        }

        if (idle && !IsGrounded())
        {
            animator.Play("PlayerIdle");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Elevator"))
        {
            transform.SetParent(collision.gameObject.transform, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            animator.Play("PlayerIdle");
        }
    }

    private bool IsGrounded()
    {
        return groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}