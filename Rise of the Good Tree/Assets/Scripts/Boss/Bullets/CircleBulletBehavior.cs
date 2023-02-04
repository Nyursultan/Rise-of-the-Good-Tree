using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBulletBehavior : MonoBehaviour
{
    const float fullCircleAngle = 360;
    [SerializeField]
    int countBullet = 30;

    [SerializeField]
    float stopTime1 = 0.1f,stopTime2 = 0.5f;

    [SerializeField]
    GameObject bullet;

    float deltaAngle = 0;

    List<Bullet> generatedBullets = new List<Bullet>();
    void Start()
    {
        deltaAngle = fullCircleAngle / countBullet;

        SpawnBullets();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBullets()
    {
        float angle = 0;
        for (int i = 0; i < countBullet; i++)
        {
            GameObject currentBullet = Instantiate(bullet, transform.position,Quaternion.identity);

            currentBullet.transform.eulerAngles = new Vector3(0,0,angle);

            Bullet bulletComponent = currentBullet.GetComponent<Bullet>();
            bulletComponent.Fire(currentBullet.transform.right);

            generatedBullets.Add(bulletComponent);
            
            angle += deltaAngle;
        }
        StartCoroutine(StopBullets());
    }

    IEnumerator StopBullets()
    {
        yield return new WaitForSeconds(stopTime1);

        foreach (Bullet bulletComponent in generatedBullets) 
        {
            bulletComponent.enabled = false;
        }

        yield return new WaitForSeconds(stopTime2);

        foreach (Bullet bulletComponent in generatedBullets)
        {
            bulletComponent.enabled = true;
        }
    }
}
