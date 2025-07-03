using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void PlayAnimationsSequentially(List<string> animationNames)
    {
        StartCoroutine(PlayAnimations(animationNames));
    }

    private IEnumerator PlayAnimations(List<string> animationNames)
    {
        foreach (string animName in animationNames)
        {
            animator.Play(animName);
            // Ждём, пока анимация не закончится
            yield return new WaitUntil(() =>
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f &&
                !animator.IsInTransition(0)
            );
        }
    }

    // Например, из другого скрипта:
    //List<string> anims = new List<string> { "isJump" };
    //GetComponent<AnimatorController>().PlayAnimationsSequentially(anims);
        
        //если анимация проигрывается то не срабатывает метод
    //var state = anim.GetCurrentAnimatorStateInfo(0);
    //if (!state.IsName("isJump") && !state.IsName("isAttack") && !state.IsName("isFall"))
}
