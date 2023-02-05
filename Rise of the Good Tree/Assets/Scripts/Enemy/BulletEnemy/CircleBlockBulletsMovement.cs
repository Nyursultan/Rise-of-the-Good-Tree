using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBlockBulletsMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2, rotateSpeed = 200;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime);
    }
}
