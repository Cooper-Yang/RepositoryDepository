using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 velocity;
    public float startVel;
    Rigidbody2D rb;
    AudioSource source;
    Vector3 defPos;
    public float verticalBounce;
    public float velocityIncrementAmount;
    bool onFloor;
    bool jumpFlag;
    public float jumpSpd;

    public void Start()
    {
        //velocity = Vector2.right * startVel;
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        defPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpFlag = true;
        }
    }

    private void FixedUpdate()
    {
        //float spdMultiplier = 1.1f;
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        Vector2 myPos = transform.position;
        Vector2 leftPoint = myPos + (Vector2.left * (box.size.x / 2f));
        RaycastHit2D ray = Physics2D.Raycast(leftPoint, Vector2.down, box.size.y / 2f + .01f, LayerMask.GetMask("Floor"));
        Vector2 rightPoint = myPos + (Vector2.right * (box.size.x / 2f));
        RaycastHit2D ray2 = Physics2D.Raycast(rightPoint, Vector2.down, box.size.y / 2f + .01f, LayerMask.GetMask("Floor"));
        if (ray || ray2)
            onFloor = true;
        else
        {
            onFloor = false;
            velocity.y -= .0981f;//-.1f + spdMultiplier * Time.deltaTime
        }

        if (onFloor && jumpFlag)
        {
            jumpFlag = false;
            velocity += Vector2.up * jumpSpd;
        }


        rb.MovePosition((Vector2)transform.position + velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collide(collision);
        source.Play();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Collide(collision);
    }

    void Collide(Collision2D collision)
    {
        float mag = velocity.magnitude;
        Vector2 norm = collision.GetContact(0).normal;
        float dot = Vector2.Dot(-norm, velocity);
        velocity += norm * (dot);
    }


    public void Reset(bool scoredRight)
    {
        transform.position = defPos;
        if (scoredRight)
            velocity = Vector2.right * startVel;
        else
            velocity = -Vector2.right * startVel;

    }
}