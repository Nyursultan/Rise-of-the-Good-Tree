using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum EnemyStates
{ 
    WaitState,
    ChaseState,
    ShootState
}

public class EnemyMovement : MonoBehaviour
{
    EnemyStates state;

    GameObject player;

    [SerializeField]
    float speed, startDistance, stopDistance;

    EnemyShoot shoot;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Body");

        state = EnemyStates.WaitState;

        shoot = GetComponent<EnemyShoot>();
    }

    void Update()
    {
        state = UpdateState();

        switch (state)
        {
            case EnemyStates.ChaseState:
                Move();
                break;
            case EnemyStates.ShootState:
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

    EnemyStates UpdateState()
    {
        float distanceBetween = Vector3.Distance(transform.position, player.transform.position);

        if (distanceBetween <= startDistance && distanceBetween >= stopDistance)
            return EnemyStates.ChaseState;
        

        if (distanceBetween >= startDistance)
            return EnemyStates.WaitState;

        if (distanceBetween <= stopDistance)
            return EnemyStates.ShootState;

        return EnemyStates.WaitState;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, startDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}
