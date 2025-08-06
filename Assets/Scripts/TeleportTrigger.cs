using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    [SerializeField] private int numberCheackPoint;
    [SerializeField] CheackPointController cheackPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            cheackPoint.TpCheackPoint(numberCheackPoint);
        }
    }
}
