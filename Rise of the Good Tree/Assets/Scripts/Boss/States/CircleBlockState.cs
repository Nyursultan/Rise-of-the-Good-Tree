using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBlockState : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    GameObject []startPoints;

    [SerializeField]
    GameObject circleBlockBullets;

    [SerializeField]
    float delay;

    float time = 0;

    void Start()
    {
        time = delay;
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
            FireCircleBullet();
            time = 0;
        }
    }

    public void FireCircleBullet()
    {
        int index = Random.Range(0,2);

        GameObject currentBullet = Instantiate(circleBlockBullets, startPoints[index].transform.position, Quaternion.identity);
    }
}
