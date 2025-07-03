using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpheaval : MonoBehaviour
{
    [SerializeField] private float gravity;
    private Rigidbody2D player;
    private Transform transform;
    private float gravity1;
    private MovementController movement;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        movement = GetComponent<MovementController>();

        gravity1 = gravity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Upheaval();
        }
    }

    public void Upheaval()
    {
        player.gravityScale = gravity1 * -1;
        gravity1 = player.gravityScale;

        Vector3 rotate = transform.eulerAngles;
        rotate.z += 180;
        transform.rotation = Quaternion.Euler(rotate);
    }
}