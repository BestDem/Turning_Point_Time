using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]

public class MovementController : MonoBehaviour
{
    public static MovementController Instance;

    [Header("Movement vars")]
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded = false; 
    [SerializeField] private bool canMove = true;
    [SerializeField] private float acceleration = 10f;
    private float currentSpeed = 0f;

    [Header("Settings")]
    //[SerializeField] private Animator animator; 
    [SerializeField] private SpriteRenderer playerRotation;
    [SerializeField] private float jumpOffSet = 0.1f;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Transform groundColliderTransform;
    //[SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckInterval = 0.1f; // Интервал проверки в секундах
    private JumpController jumpController;
    private float nextGroundCheckTime;
    private Rigidbody2D rb;
    private Transform player;
    [SerializeField] private Transform firePoint;

    public bool IsLookRight => !playerRotation.flipX;
    public bool IsGrounded => isGrounded;

    private void FixedUpdate()
    {
        if (Time.time >= nextGroundCheckTime)
        {
            isGrounded = Physics2D.OverlapCircle(groundColliderTransform.position, jumpOffSet, groundMask);
            nextGroundCheckTime = Time.time + groundCheckInterval;
        }
    }

    void Awake()
    {
        Instance = this;
        jumpController = GetComponent<JumpController>();
        player = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction, bool isJumpButtonPress)
    {
        if (!canMove) return;

        if (isJumpButtonPress & isGrounded)
        {
            jumpController.Jump();
        }

        if (Mathf.Abs(direction) > 0.01f)
        {
            PlayerRotation(direction);
            HorizontalMovement(direction);
            {
                anim.SetBool("isRunning", true);
            }

        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void HorizontalMovement(float direction)
    {
        if (isGrounded)
        {
            float targetSpeed = direction * speed;
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.fixedDeltaTime);
            rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
        }
    }


    private void PlayerRotation(float direction)
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
