using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFlyingCarrot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet, startPoint;

    Transform playerPoint;

    [SerializeField]
    float delay;

    float time = 0;

    Animator animator;
    private void Start()
    {
        playerPoint = GameObject.FindGameObjectWithTag("Body").transform;
        animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        time += Time.deltaTime;

        if (time >= delay)
        {
            animator.SetTrigger("isFire");
            time = 0;
        }
    }

    public void Fire()
    {
        GameObject currentBullet = Instantiate(bullet, startPoint.transform.position, Quaternion.identity);

        Bullet bulletComponent = currentBullet.GetComponent<Bullet>();

        Vector3 direction = playerPoint.position - transform.position;

        bulletComponent.Fire(direction);
    }
}
