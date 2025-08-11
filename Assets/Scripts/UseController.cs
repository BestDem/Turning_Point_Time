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
    
    // Переменная для хранения позиции первого касания
    private Vector2 firstTouchPosition;

    private void Update()
    {

        // Обработка касаний для мобильных устройств
        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);
            if (firstTouch.phase == UnityEngine.TouchPhase.Began)
            {
                Shoot(firstTouch.position);
            }
        }
        // Обработка мыши для редактора/ПК
        else if (Input.GetMouseButtonDown(0))
        {
            Shoot(Input.mousePosition);
        }
    }

    public void Shoot(Vector2 screenPosition)
    {
        AnimatorController.singltonAnim.PlayAnimations("isAttack", true);

        // Преобразуем позицию экрана в мировые координаты
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane));
        Vector2 direction = (worldPos - transform.position).normalized;

        int layerMask = ~(1 << LayerMask.NameToLayer("NoRaycast"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 80f,layerMask);
        Physics.GetIgnoreLayerCollision(8,5);

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
        //Debug.DrawRay(transform.position, direction * 10f, Color.red, 1f);

    }
}
