using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    Damageble damageble;

    [SerializeField]
    NextLevel nextLevel;
    void Start()
    {
        damageble = GetComponent<Damageble>();

        damageble.OnCharacterDeadEvent += Damageble_OnCharacterDeadEvent;
    }

    private void Damageble_OnCharacterDeadEvent(object obj)
    {
        transform.parent.GetComponent<StickmanController>().enabled = false;
        StartCoroutine(nextLevel.GoToMainMenu());
    }

    void Update()
    {
        
    }
}
