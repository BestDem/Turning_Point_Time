using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] private float damage;
    private bool isDamage = true;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Health>(out var health) && isDamage && collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isDamage = false;
            //AnimationPlayerController.singltonAnim.AnimatorPlayer("isDamage", true);
            health.GetDamage(damage);
            StartCoroutine(WaiteSec());
        }
        else
            return;
    }

    IEnumerator WaiteSec()
    {
        yield return new WaitForSeconds(1f);
        isDamage = true;
    }
}
