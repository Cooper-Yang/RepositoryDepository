using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    Rigidbody2D rb;
    public float paddleSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()//physics is using fixed update(because the update is fixed per frame rate)
    {
        float input = 0;
        input += Input.GetKey(upKey) ? 1f : 0f;
        input += Input.GetKey(downKey) ? -1f : 0f;

        if (input != 0)
            rb.MovePosition(transform.position + Vector3.up * input * paddleSpeed);
    }
}
