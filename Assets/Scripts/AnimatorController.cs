using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public static AnimatorController singltonAnim { get; private set; }
    private Animator animator;

    private void Awake()
    {
        singltonAnim = this;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimations(string animationNames, bool isAnimation)
    {

        if (animationNames == "isAttack")
            animator.SetTrigger("isAttack");
        if (animationNames == "isJump")
            animator.SetTrigger("isJump");

        animator.SetBool(animationNames, isAnimation);
    }

    // Например, из другого скрипта:
    //List<string> anims = new List<string> { "isJump" };
    //GetComponent<AnimatorController>().PlayAnimationsSequentially(anims);
        
        //если анимация проигрывается то не срабатывает метод
    //var state = anim.GetCurrentAnimatorStateInfo(0);
    //if (!state.IsName("isJump") && !state.IsName("isAttack") && !state.IsName("isFall"))
}
