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
        bool isFireButtonPress = Input.GetButtonDown("Fire1");

        playerController.Move(horizontalDirection, isJumpButtonPress, isFireButtonPress);
        //playerInput.Move(horizontalDirection, isJumpButtonPress);
        //shooter.FireButtonDown(isFireButtonPress);

    }
}

