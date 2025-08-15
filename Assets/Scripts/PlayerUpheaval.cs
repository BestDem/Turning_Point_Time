using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpheaval : MonoBehaviour
{

    [SerializeField] private float gravity;
    [SerializeField] private float timerGravity;
    private Rigidbody2D player;
    private Transform transform;
    private static bool isGravity = true;
    private float gravity1;
    public static bool IsGravity => isGravity;
    private float timer = 0;
    private bool canUseGrav = true;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();

        gravity1 = gravity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canUseGrav)
        {
            Upheaval();
        }
        if (canUseGrav == false)
        {
            timer += Time.deltaTime;
            if (timer > timerGravity)
            {
                canUseGrav = true;
                timer = 0;
            }
        }
    }

    public void Upheaval()
    {
        canUseGrav = false;
        player.gravityScale = gravity1 * -1;
        gravity1 = player.gravityScale;
        isGravity = !isGravity;

        Vector3 rotate = transform.eulerAngles;
        rotate.z += 180;
        transform.rotation = Quaternion.Euler(rotate);
    }

    public void SpawnPlayerGravity()
    {
        if (isGravity == false && canUseGrav)
        {
            Upheaval();
            player.velocity = new Vector2(0,0);
        }
    }

    public void UpHeavalButton()
    {
        if(canUseGrav)
            Upheaval();
    }
}