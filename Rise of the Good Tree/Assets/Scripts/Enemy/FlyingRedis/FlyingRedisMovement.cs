using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum RedisStates
{
    WaitState,
    ChaseState
}

public class FlyingRedisMovement : MonoBehaviour
{
    RedisStates state;

    GameObject player;

    [SerializeField]
    float speed, startDistance, waitTime, damage;//waitTime время остановки после касания ГГ

    float time;

    SpriteRenderer sprite;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Body");
        sprite = GetComponentInChildren<SpriteRenderer>();
        state = RedisStates.WaitState;
    }

    
    void Update()
    {
        float distanceBetween = Vector3.Distance(transform.position, player.transform.position);
        
        FlipSprite();
        
        switch (state)
        {
            case RedisStates.WaitState:
                time += Time.deltaTime;
                if (distanceBetween <= startDistance && time >= waitTime)
                    state = RedisStates.ChaseState;
                else
                    time = time >= waitTime ? 0 : time;
                break;
            case RedisStates.ChaseState:
                Move();
                if (distanceBetween > startDistance)
                    state = RedisStates.WaitState;
                break;
        }
    }

    public void Move()
    {
        float step = speed * Time.deltaTime;

        float distanceBetween = Vector3.Distance(transform.position, player.transform.position);

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

    }

    public void FlipSprite()
    {
        Vector3 direction = player.transform.position - transform.position;

        print(direction.x);
        if (direction.x < 0)
            sprite.flipX = false;
        else
            sprite.flipX = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Body")
        {
            Damageble damageble = collision.GetComponent<Damageble>();
            damageble?.Damage(damage);

            state = RedisStates.WaitState;
            time = 0;
        }
    }
}
