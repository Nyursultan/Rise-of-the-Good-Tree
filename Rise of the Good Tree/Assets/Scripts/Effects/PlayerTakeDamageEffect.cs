using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamageEffect : MonoBehaviour
{
    [SerializeField]
    int maxCountFrame = 20;

    [SerializeField]
    Color damageColor;

    Damageble damageble;
    SliderController healthBar;

    SpriteRenderer[] sprites;
    List<Color> colors = new List<Color>();

    int count = 0;
    void Start()
    {
        damageble = GetComponent<Damageble>();
        damageble.OnCharacterTakeDamageEvent += Damageble_OnCharacterTakeDamageEvent;
        sprites = transform.parent.GetComponentsInChildren<SpriteRenderer>();

        healthBar = GameObject.Find("HealthBar").GetComponent<SliderController>();

        for (int i = 0; i < sprites.Length; i++)
        {
            colors.Add(sprites[i].color);
        }
    }

    private void Damageble_OnCharacterTakeDamageEvent(object obj)
    {
        healthBar.SetHealth(damageble.HitPoint);
        FindObjectOfType<AudioManager>().Play("PlayerHit");
        StartCoroutine(TakeDamageAnim());
    }


    IEnumerator TakeDamageAnim()
    {
        float step = 0;

        while (count <= maxCountFrame)
        {
            count++;
            step += 10 * Time.deltaTime;
            foreach (var sprite in sprites)
                sprite.color = Color.Lerp(sprite.color, damageColor, step);
            
            yield return null;
        }
        count = 0;

        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].color = colors[i];
            //print(colors[i].r);
        }
    }
}
