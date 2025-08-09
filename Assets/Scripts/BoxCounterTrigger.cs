using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCounterTrigger : MonoBehaviour
{
    [SerializeField] private GameObject windActive;
    [SerializeField] private float needBox;
    private float count = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<ChangingGravity>(out var changing))
            CountBox();
    }

    private void CountBox()
    {
        count = count + 1;
        if (count == needBox)
            windActive.SetActive(false);
    }
}
