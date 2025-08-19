using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UseController : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AnimatorObjects animatorBullet;
    [SerializeField] private PlayerUpheaval playerUpheaval;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerUpheaval.CanUseGrav)
        {
            Shoot(Input.mousePosition);
        }
    }

    public void Shoot(Vector2 screenPosition)
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            playerUpheaval.UseGravity();
            AnimatorController.singltonAnim.PlayAnimations("isAttack", true);
            animatorBullet.PlayAnimations("isAttack");
            soundManager.PlaySongByIndex(6);

            // Преобразуем позицию экрана в мировые координаты
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane));
            Vector2 direction = (worldPos - transform.position).normalized;

            int layerMask = ~(1 << LayerMask.NameToLayer("NoRaycast"));
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 80f, layerMask);
            Physics.GetIgnoreLayerCollision(8, 5);

            if (hit.collider != null)
            {
                ChangingGravity gravityController = hit.collider.GetComponent<ChangingGravity>();
                if (gravityController != null)
                {
                    gravityController.UsingGravity();
                }
            }
        }

        //PlayerFall();

            // Для визуализации луча в редакторе
            //Debug.DrawRay(transform.position, direction * 10f, Color.red, 1f);

    }
}
