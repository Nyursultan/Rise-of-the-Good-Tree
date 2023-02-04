using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEveMovement : MonoBehaviour
{
    public float speed;
    private bool facingRight;
    public bool chase;
    public Transform startingPoint;
    public GameObject player;
    private Rigidbody2D rb;
    public int UnitsToMove = 5;
    private float startPos;
    private float endPos;

    public bool moveRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
        endPos = startPos + UnitsToMove;
        facingRight = transform.localScale.x > 0;
        chase = false;
    }

    private void Update()
    {
        if (player == null)
            return;
        if (chase)
        {
            Chase();
            Flip();
        }
        else
            ReturnStartPoint();
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
        if (player.transform.position == transform.position)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (moveRight)
        {
            rb.AddForce(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
