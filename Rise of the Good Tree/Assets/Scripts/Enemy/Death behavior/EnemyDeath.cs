using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    Damageble damageble;
    void Start()
    {
        Damageble damageble = GetComponent<Damageble>();
        if (damageble != null)
            damageble.OnCharacterDeadEvent += Damageble_OnCharacterDeadEvent;
    }

    private void Damageble_OnCharacterDeadEvent(object obj)
    {
        Destroy(gameObject);
    }

    void Update()
    {

    }
}
