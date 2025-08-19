using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBullet : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer playerRotation;

    private void Start()
    {
        playerRotation = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void PlayAnimations(string animationNames)
    {
        if (animationNames == "isAttack")
            animator.SetTrigger("isAttack");
        else
            return;
    }

    public void FlipAnimBullet(bool flip)
    {
        playerRotation.flipX = flip;
    }
}
