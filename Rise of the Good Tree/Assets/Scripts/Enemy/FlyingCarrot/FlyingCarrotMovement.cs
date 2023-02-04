using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum CarrotStates
{ 
    WaitState,
    ChaseState,
    ShootState
}

public class FlyingCarrotMovement : MonoBehaviour
{
    CarrotStates state;

    GameObject player;

    [SerializeField]
    float speed, startDistance, stopDistance;

    ShootFlyingCarrot shoot;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Body");

        state = CarrotStates.WaitState;

        shoot = GetComponent<ShootFlyingCarrot>();
    }

    void Update()
    {
        state = UpdateState();

        switch (state)
        {
            case CarrotStates.ChaseState:
                Move();
                break;
            case CarrotStates.ShootState:
                Shoot();
                break;
        }
    }


    public void Move()
    {
        float step = speed * Time.deltaTime;

        float distanceBetween = Vector3.Distance(transform.position, player.transform.position);

        if (distanceBetween >= stopDistance)
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

    public void Shoot()
    {
        shoot?.Shoot();
    }

    CarrotStates UpdateState()
    {
        float distanceBetween = Vector3.Distance(transform.position, player.transform.position);

        if (distanceBetween <= startDistance && distanceBetween >= stopDistance)
            return CarrotStates.ChaseState;
        

        if (distanceBetween >= startDistance)
            return CarrotStates.WaitState;

        if (distanceBetween <= stopDistance)
            return CarrotStates.ShootState;

        return CarrotStates.WaitState;
    }
}
