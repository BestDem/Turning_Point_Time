using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorObjects : MonoBehaviour
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
        animator.SetTrigger(animationNames);
    }

    public void FlipAnimBullet(bool flip)
    {
        playerRotation.flipX = flip;
    }
}
