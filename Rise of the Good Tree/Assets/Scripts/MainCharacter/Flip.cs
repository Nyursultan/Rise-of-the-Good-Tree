using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private bool facingRight = true;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight)
        {
            _Flip();
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && facingRight)
        {
            _Flip();

        }
    }

    void _Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
