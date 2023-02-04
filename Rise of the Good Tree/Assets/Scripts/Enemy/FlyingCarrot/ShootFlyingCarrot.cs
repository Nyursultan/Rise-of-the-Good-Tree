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

    private void Start()
    {
        playerPoint = GameObject.FindGameObjectWithTag("Body").transform;
    }

    public void Shoot()
    {
        time += Time.deltaTime;

        if (time >= delay)
        {
            Fire();
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
