using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheackpointTrigger : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private CheackPointController cheackPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            cheackPoint.ActivateNextCheckPoint(number);
        }
    }
}