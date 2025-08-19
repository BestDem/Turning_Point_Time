using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingGravity : MonoBehaviour
{
    private float startGravity;
    private Rigidbody2D rb;
    private float gravity;

    private void Update()
    {
        float velocityY = rb.velocity.y;
        velocityY = Mathf.Clamp(velocityY, -3, 3);
        rb.velocity = new Vector2(rb.velocity.x, velocityY);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startGravity = rb.gravityScale;
        gravity = startGravity;
    }
    public void UsingGravity()
    {
        rb.gravityScale = gravity * -1;
        gravity = rb.gravityScale;
    }
}
