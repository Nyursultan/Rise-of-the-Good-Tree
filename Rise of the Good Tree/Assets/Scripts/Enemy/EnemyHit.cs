using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private GameObject body;
    public float damage = 105f;
    Damageble damageble;

    [SerializeField]
    float delay;

    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Body");
        damageble = body.GetComponent<Damageble>();
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Body")
        {
            if (damageble != null)
            {
                damageble.Damage(damage);
            }
        }
    }


}
