using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageEffect : MonoBehaviour
{
    [SerializeField]
    int maxCountFrame;

    [SerializeField]
    Color color;

    Damageble damageble;

    [SerializeField]
    SpriteRenderer sprite;

    int count;
    void Start()
    {
        damageble = GetComponent<Damageble>();

        if (damageble != null)
            damageble.OnCharacterTakeDamageEvent += Damageble_OnCharacterTakeDamageEvent;
    }

    private void Damageble_OnCharacterTakeDamageEvent(object obj)
    {
        StartCoroutine(TakeDamageAnim());
    }


    IEnumerator TakeDamageAnim()
    {
        float step = 0;

        while (count <= maxCountFrame)
        {
            count++;
            step += 10 * Time.deltaTime;
            sprite.color = Color.Lerp(sprite.color, color, step);
            yield return null;
        }
        count = 0;
        sprite.color = Color.white;

    }
}
