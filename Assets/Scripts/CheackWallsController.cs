using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheackWallsController : MonoBehaviour
{
    [SerializeField] private Transform leftWallCheck; // Точка проверки стены
    [SerializeField] private Transform leftWallCheckUp;
    [SerializeField] private Transform rightWallCheck;
    [SerializeField] private Transform rightWallCheckUp;
    private MovementController movementController;

    private void Start()
    {
        movementController = GetComponent<MovementController>();
    }
    public void MovementDir(float direction)
    {
        bool canMove = direction >= 0 ^ PlayerUpheaval.IsGravity == false ? !IsWallOnRight() : !IsWallOnLeft();

        if (canMove)
        {
            movementController.HorizontalMovement(direction);
        }
        else
        {
            movementController.HorizontalMovement(0);
        }
    }

        private bool IsWallOnLeft()
    {
        int groundLayer = LayerMask.GetMask("Ground");
        RaycastHit2D hitLeft = Physics2D.Raycast(leftWallCheck.position, Vector2.left, 0.15f, groundLayer);
        RaycastHit2D hitLeftUp = Physics2D.Raycast(leftWallCheckUp.position, Vector2.left, 0.15f, groundLayer);
        if (hitLeft.collider != null || hitLeftUp.collider != null)
            return true;
        else
            return false;
    }

    // Проверка стены справа
    private bool IsWallOnRight()
    {
        int groundLayer = LayerMask.GetMask("Ground");
        RaycastHit2D hitRigth = Physics2D.Raycast(rightWallCheck.position, Vector2.right, 0.15f, groundLayer);
        RaycastHit2D hitRigthUp = Physics2D.Raycast(rightWallCheckUp.position, Vector2.right, 0.15f, groundLayer);
        if (hitRigth.collider != null || hitRigthUp.collider != null)
            return true;
        else
            return false;
    }
}