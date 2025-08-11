using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]

public class MovementController : MonoBehaviour
{

    [Header("Movement vars")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float acceleration = 10f;
    private SpriteRenderer playerRotation;
    private float currentSpeed = 0f;

    [Header("Settings")]
    [SerializeField] private float jumpOffSet = 0.1f;
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckInterval = 0.1f; // Интервал проверки в секундах
    private float nextGroundCheckTime;
    private bool canMove = true;
    private Rigidbody2D rb;
    public bool IsGrounded => isGrounded;
    public bool CanMove => canMove;

    private void FixedUpdate()
    {
        if (Time.time >= nextGroundCheckTime)
        {
            isGrounded = Physics2D.OverlapCircle(groundColliderTransform.position, jumpOffSet, groundMask);
            nextGroundCheckTime = Time.time + groundCheckInterval;
        }
    }

    void Start()
    {
        playerRotation = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void HorizontalMovement(float direction)
    {
        float targetSpeed = direction * speed;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.fixedDeltaTime);
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
    }

    public void PlayerRotation(float direction)
    {
        if (PlayerUpheaval.IsGravity)
        {
            firePoint.localPosition = new Vector2(direction > 0 ? 0.1f : -0.1f, firePoint.localPosition.y);
            playerRotation.flipX = direction < 0;
        }
        else
        {
            firePoint.localPosition = new Vector2(direction > 0 ? -0.1f : 0.1f, firePoint.localPosition.y);
            playerRotation.flipX = direction > 0;
        }
    }
    
    public void SetCanMove(bool value)
    {
        canMove = value;
    }
    
}