using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform" && Input.GetAxisRaw("Horizontal") != 0)
        {
            FindObjectOfType<AudioManager>().Play("Step");
        }
    }
}
