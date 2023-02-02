/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] private int speed = 300;
    public Rigidbody2D rb;
    public Camera cam;
    public KeyCode mousebutton;

    private void Update()
    {
        Vector3 playerPos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);
        Vector3 difference = playerPos - transform.position;
        float rotationZ = Mathf.Atan(difference.x - difference.y) * Mathf.Rad2Deg;

        if (Input.GetKey(mousebutton))
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rotationZ, speed * Time.fixedDeltaTime));
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    int speed = 300;
    public Rigidbody2D rb;
    public Camera camera;
    public KeyCode mousebutton;


    private void Update()
    {

        var qTo = Quaternion.LookRotation(camera.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        qTo = Quaternion.Slerp(transform.rotation, qTo, speed * Time.deltaTime);

        if (Input.GetKey(mousebutton))
        {
            rb.MoveRotation(qTo);
        }

    }
}
