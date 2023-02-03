using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageble : MonoBehaviour
{
    [SerializeField]
    float hp = 100;
    public float HitPoint { get => hp; }


    public event Action<object> OnCharacterDeadEvent;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            OnCharacterDeadEvent?.Invoke(this);
        }
    }
}
