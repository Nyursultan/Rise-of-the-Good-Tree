using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShootingState : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    GameObject bullet, startPoint;

    [SerializeField]
    float delay;

    float time = 0;

    Animator animator;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Body");
        animator = GetComponent<Animator>();
    }

    public void Callback(BossStateBehavior bossStateBehavior)
    {
        Shoot();
    }

    public void Shoot()
    {
        time += Time.deltaTime;

        if (time >= delay)
        {
            animator.SetTrigger("isFire");
            //Fire();
            time = 0;
        }
    }


    public void Fire()
    {
        GameObject currentBullet = Instantiate(bullet, startPoint.transform.position, Quaternion.identity);

        Bullet bulletComponent = currentBullet.GetComponent<Bullet>();

        Vector3 direction = player.transform.position - transform.position;

        bulletComponent.Fire(direction);
    }
}
