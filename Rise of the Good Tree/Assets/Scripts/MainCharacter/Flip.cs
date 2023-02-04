using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private bool facingRight = true;
    private SpriteRenderer mySpriteRenderer;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight)
        {
            _Flip();
            mySpriteRenderer.flipX = false;
        }

        if (Input.GetAxisRaw("Horizontal") < 0 && facingRight)
        {
            _Flip();
            mySpriteRenderer.flipX = true;
        }
    }

    void _Flip()
    {
        Vector3 currentScale = transform.localScale;

        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
