using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class PlayerInput : MonoBehaviour
{
    private MovementController playerMovement;
    //private Shooter shooter;
    
    private void Awake()
    {
        playerMovement = GetComponent<MovementController>();
        //shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        bool isJumpButtonPress = Input.GetButtonDown("Jump");
        bool isFireButtonPress = Input.GetButtonDown("Fire1");

        playerMovement.Move(horizontalDirection, isJumpButtonPress);
        //shooter.FireButtonDown(isFireButtonPress);

    }
}

