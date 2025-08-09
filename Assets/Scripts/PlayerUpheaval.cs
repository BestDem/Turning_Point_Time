using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpheaval : MonoBehaviour
{
    [SerializeField] private float gravity;
    private Rigidbody2D player;
    private Transform transform;
    private static bool isGravity = true;
    private float gravity1;
    public static bool IsGravity => isGravity;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();

        gravity1 = gravity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Upheaval();
        }
    }

    public void Upheaval()
    {
        player.gravityScale = gravity1 * -1;
        gravity1 = player.gravityScale;
        isGravity = !isGravity;

        Vector3 rotate = transform.eulerAngles;
        rotate.z += 180;
        transform.rotation = Quaternion.Euler(rotate);
    }

    public void SpawnPlayerGravity()
    {
        if (isGravity == false)
            Upheaval();
    }

    public void UpHeavalButton()
    {
        Upheaval();
    }
}