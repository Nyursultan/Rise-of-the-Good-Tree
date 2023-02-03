using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipStartBullet : MonoBehaviour
{
    private bool facingRight = true;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight)
        {
            Flip();
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && facingRight)
        {
            Flip();

        }
    }

    void Flip()
    {
        Vector3 currentPosition = gameObject.transform.localPosition;
        currentPosition.x *= -1;
        gameObject.transform.localPosition = currentPosition;

        facingRight = !facingRight;
    }
}
