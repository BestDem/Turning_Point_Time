using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravityTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ChangingGravity>(out var component))
            component.UsingGravity();
    }

}
