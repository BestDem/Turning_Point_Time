using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class UseController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private float timer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    //private void CannonShot()

    //var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //Ray ray = new Ray(transform.position, Vector3.left);

    //RaycastHit hit;
    // if (Physics.Raycast(ray, out hit, 10f))
    //{
    //    Debug.Log(hit.transform.position);
    //}

    public void Shoot()
    {
        animator.SetTrigger("isAttack");

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position).normalized;

        int layerMask = ~(1 << LayerMask.NameToLayer("NoRaycast"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 80f, layerMask);

        if (hit.collider != null)
        {
            ChangingGravity gravityController = hit.collider.GetComponent<ChangingGravity>();
            if (gravityController != null)
            {
                gravityController.UsingGravity();
            }
        }

        //PlayerFall();

        // Для визуализации луча в редакторе
        Debug.DrawRay(transform.position, direction * 10f, Color.red, 1f);

    }
}
