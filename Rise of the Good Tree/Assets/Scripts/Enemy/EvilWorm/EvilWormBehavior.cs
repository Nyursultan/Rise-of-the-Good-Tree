using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum EvilWormStates
{ 
    WaitState,
    ShowState,
    ShootState,
    HideState
}

public class EvilWormBehavior : MonoBehaviour
{
    GameObject player;

    EvilWormStates state;

    [SerializeField]
    float speed, waitTime, startDistance;

    ShootEvilWorm shoot;

    [SerializeField]
    Transform endPos;

    Vector3 startPos;

    float time;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Body");
        shoot = GetComponent<ShootEvilWorm>();

        state = EvilWormStates.WaitState;

        startPos = transform.position;
    }

    
    void Update()
    {
        float distanceBetween = Vector3.Distance(transform.position, player.transform.position);


        switch (state)
        {
            case EvilWormStates.WaitState:
                WaitStateNext(distanceBetween);
                break;
            case EvilWormStates.ShowState:
                ShowMove();
                break;
            case EvilWormStates.ShootState:
                Shoot();
                break;
            case EvilWormStates.HideState:
                HideMove();
                break;
        }
    }


    void WaitStateNext(float distanceBetween)
    {
        time += Time.deltaTime;
        if (distanceBetween <= startDistance && time >= waitTime)
        {
            state = EvilWormStates.ShowState;
            time = 0;
        }
    }
    private void ShowMove()
    {
        float distance = Vector3.Distance(transform.position, endPos.position);
        float step = speed * Time.deltaTime;

        if (distance >= float.Epsilon)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, step);
        }
        else 
        {
            time += Time.deltaTime;
            if (time >= waitTime)
            {
                time = 0;
                state = EvilWormStates.ShootState;
            }
        }
    }


    private void HideMove()
    {
        float distance = Vector3.Distance(transform.position, startPos);
        float step = speed * Time.deltaTime;

        if (distance >= float.Epsilon)
        {

            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
        else
        {
            state = EvilWormStates.WaitState;
        }
    }
    void Shoot()
    {
        bool isShoot = shoot.Shoot();

        if (isShoot == false)
        {
            time += Time.deltaTime;

            if (time >= waitTime)
            {
                state = EvilWormStates.HideState;
                time = 0;
                shoot.EndFire();
            }
        }
    }
}
