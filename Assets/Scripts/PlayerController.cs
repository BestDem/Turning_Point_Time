using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CheackWallsController cheackWalls;
    [SerializeField] private MovementController movementController;
    [SerializeField] private JumpController jumpController;

    public void Move(float direction, bool isJumpButtonPress)
    {
        if (movementController.CanMove == false) return;
        cheackWalls.MovementDir(direction);

        if (isJumpButtonPress & movementController.IsGrounded)
        {
            jumpController.Jump();
        }

        if (Mathf.Abs(direction) > 0.01f)
        {
            movementController.PlayerRotation(direction);
            {
                AnimatorController.singltonAnim.PlayAnimations("isRunning", true);
            }

        }
        else
        {
            AnimatorController.singltonAnim.PlayAnimations("isRunning", false);
        }
    }
}
