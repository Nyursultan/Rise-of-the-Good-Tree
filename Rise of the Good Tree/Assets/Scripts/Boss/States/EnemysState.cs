using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysState : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemys;

    bool isSpawn = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Callback(BossStateBehavior bossStateBehavior)
    {

        if (isSpawn)
            return;

        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i].SetActive(true);
        }
        isSpawn = true;
    }
}
