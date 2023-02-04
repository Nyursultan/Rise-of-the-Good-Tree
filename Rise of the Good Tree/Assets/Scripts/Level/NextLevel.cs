using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    Image nextLevelEffectSprite;

    float count = 0;

    [SerializeField]
    float speed;
    void Start()
    {
        StartCoroutine(StartLevelEffect());
    }

    void Update()
    {
        
    }


    IEnumerator StartLevelEffect()
    {
        float alfa = 255;

        while (alfa > 0 )
        {
            alfa -= speed * Time.deltaTime;

            float r = nextLevelEffectSprite.color.r;
            float g = nextLevelEffectSprite.color.g;
            float b = nextLevelEffectSprite.color.b;

            nextLevelEffectSprite.color = new Color(r,g,b,alfa/255);
            yield return null;
        }
    }

    public IEnumerator EndLevelEffect()
    {
        float alfa = 0;

        while (alfa < 255)
        {
            alfa += speed * Time.deltaTime;

            float r = nextLevelEffectSprite.color.r;
            float g = nextLevelEffectSprite.color.g;
            float b = nextLevelEffectSprite.color.b;

            nextLevelEffectSprite.color = new Color(r, g, b, alfa / 255);
            yield return null;
        }
    }

    public void NextScene()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
