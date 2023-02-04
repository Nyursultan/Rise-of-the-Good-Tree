using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEvilWorm : MonoBehaviour
{
    [SerializeField]
    GameObject bullet, startPoint;

    Transform playerPoint;

    [SerializeField]
    float delay, maxCountFire;

    float time = 0;

    float currentCount = 0;
    void Start()
    {
        playerPoint = GameObject.FindGameObjectWithTag("Body").transform;
    }



    public bool Shoot()
    {
        time += Time.deltaTime;

        if (time >= delay && currentCount <= maxCountFire)
        {
            Fire();
            currentCount++;
            time = 0;
        }

        if (currentCount >= maxCountFire)
        {
            return false;//закончил стрелять
        }

        return true;
    }

    void Fire()
    {
        GameObject currentBullet = Instantiate(bullet, startPoint.transform.position, Quaternion.identity);

        Bullet bulletComponent = currentBullet.GetComponent<Bullet>();

        Vector3 direction = playerPoint.position - transform.position;

        bulletComponent.Fire(direction);
    }

    public void EndFire()
    {
        currentCount = 0;
        time = 0;
    }
}
