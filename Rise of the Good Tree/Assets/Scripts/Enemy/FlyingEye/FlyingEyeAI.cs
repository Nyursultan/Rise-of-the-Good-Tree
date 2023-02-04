using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeAI : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    /*public float fireRate = 1;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;*/
    private Transform player;
    EnemyShoot shoot;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Body").transform;
        shoot = GetComponent<EnemyShoot>();
    }

    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange)
        {
            shoot?.Shoot();
        }

        Flip();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
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