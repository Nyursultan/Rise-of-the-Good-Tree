using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private GameObject body;
    public float damage = 10f;
    Damageble damageble;

    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
        damageble = body.GetComponent<Damageble>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Body")
        {
            if (damageble != null)
            {
                //FindObjectOfType<AudioManager>().Play("TreeHit");
                damageble.Damage(damage);
            }
        }
    }


}
