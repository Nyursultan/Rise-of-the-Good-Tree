using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNextLevel : MonoBehaviour
{
    [SerializeField]
    NextLevel nextLevel;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Body")
        {
            nextLevel.NextScene();
        }
    }
}
