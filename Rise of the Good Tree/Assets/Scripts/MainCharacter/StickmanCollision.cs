using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanCollision : MonoBehaviour
{
    private bool oneSecLasted = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform" && !oneSecLasted && Input.GetAxisRaw("Horizontal") != 0)
        {
            FindObjectOfType<AudioManager>().Play("Step");
            oneSecLasted = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform" && oneSecLasted)
        {
            oneSecLasted = false;
        }
    }
}
