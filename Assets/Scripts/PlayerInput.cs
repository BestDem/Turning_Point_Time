using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        bool isJumpButtonPress = Input.GetButtonDown("Jump");

        playerController.Move(horizontalDirection, isJumpButtonPress);
    }
}

