using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum BossStates
{
    SimpleShootingState,
    CircleShootingState,
    EnemysState,
    CircleBlockState,
    DeathState
}

public class BossStateBehavior : MonoBehaviour
{
    Damageble damageble;

    BossStates state;


    //all states
    SimpleShootingState simpleShootingState;
    CircleShootingState circleShootingState;
    EnemysState enemysState;
    CircleBlockState circleBlockState;
    DeathState deathState;

    void Start()
    {
        damageble = GetComponent<Damageble>();
        state = BossStates.SimpleShootingState;
        InitStateComponent();
    }

    void InitStateComponent()
    {
        simpleShootingState = GetComponent<SimpleShootingState>();
        circleShootingState = GetComponent<CircleShootingState>();
        enemysState = GetComponent<EnemysState>();
        circleBlockState = GetComponent<CircleBlockState>();
        deathState = GetComponent<DeathState>();
    }

    void Update()
    {
        state = UpdateState();

        switch (state)
        {
            case BossStates.SimpleShootingState:
                simpleShootingState.Callback(this);
                break;
            case BossStates.CircleShootingState:
                circleShootingState.Callback(this);
                break;
            case BossStates.EnemysState:
                enemysState.Callback(this);
                simpleShootingState.Callback(this);
                break;
            case BossStates.CircleBlockState:
                circleBlockState.Callback(this);
                break;
            case BossStates.DeathState:
                deathState.Callback(this);
                break;
        }
    }


    BossStates UpdateState()
    {
        float hp = damageble.HitPoint;

        if (hp <= 500 && hp>300)
            return BossStates.SimpleShootingState;

        if (hp<=300 && hp>200)
           return BossStates.CircleShootingState;

        if(hp <= 200 && hp > 100)
           return BossStates.EnemysState;

        if (hp<=100 && hp>0)
            return BossStates.CircleBlockState;

        return BossStates.DeathState;
    }
}
