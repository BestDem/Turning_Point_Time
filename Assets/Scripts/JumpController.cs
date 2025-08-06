using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        SoundManager.singltonSound.PlaySongByIndex(1);
        AnimatorController.singltonAnim.PlayAnimations("isJump", true);

        if (PlayerUpheaval.IsGravity == true)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
        }
    }
}
