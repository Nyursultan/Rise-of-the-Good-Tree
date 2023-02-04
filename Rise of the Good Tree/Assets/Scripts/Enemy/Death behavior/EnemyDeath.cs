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
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
        StartCoroutine(DeadAnim());
    }

    IEnumerator DeadAnim()
    {
        float distance = Vector3.Distance(transform.localScale, Vector3.zero);
        float step = 0;
        while (distance >= 0.01) 
        {
            distance = Vector3.Distance(transform.localScale, Vector3.zero);
            step += 0.5f * Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, step);

            transform.eulerAngles += new Vector3(0, 0, 5f);
            yield return null;
        }

        Destroy(gameObject);
    }
}
