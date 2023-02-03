using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet, startPoint, body;
    
    [SerializeField]
    float delay;

    float time = 0;
    void Start()
    {
        
    }

    
    void Update()
    {
        time += Time.deltaTime;

        if (Input.GetMouseButton(0) && time >= delay)
        {
            Fire();
            time = 0;
        }
    }


    public void Fire()
    {
        GameObject currentBullet = Instantiate(bullet, startPoint.transform.position,Quaternion.identity);

        Bullet bulletComponent = currentBullet.GetComponent<Bullet>();

        bulletComponent.Fire(body.transform.right);
    }
}
