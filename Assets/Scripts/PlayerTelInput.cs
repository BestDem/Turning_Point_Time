using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTelInput : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    private int directionPlayer;
    private bool isJump = false;
    private bool isChangeGravity = false;

    private void FixedUpdate()
    {
        controller.Move(directionPlayer, isJump);
    }

    public void MoveDir(int direction)
    {
        directionPlayer = direction;
    }

    public void CanJump()
    {
        isJump = true;
    }
    public void CanNotJump()
    {
        isJump = false;
    }
}
