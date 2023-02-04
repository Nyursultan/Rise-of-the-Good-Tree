using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    private TakeDamageEffect flyingEye;

    private void Start()
    {
        flyingEye = GameObject.Find("FlyingEye").GetComponent<TakeDamageEffect>();
    }

    private void FlyingEyeTakeDamage()
    {
        
    }
}
