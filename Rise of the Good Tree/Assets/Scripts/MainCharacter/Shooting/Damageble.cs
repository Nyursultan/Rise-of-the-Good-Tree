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
    public event Action<object> OnCharacterTakeDamageEvent;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        hp -= damage;

        OnCharacterTakeDamageEvent?.Invoke(this);

        if (hp <= 0)
        {
            OnCharacterDeadEvent?.Invoke(this);
        }
    }
}
