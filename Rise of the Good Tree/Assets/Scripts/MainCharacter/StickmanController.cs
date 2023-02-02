using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanController : MonoBehaviour
{
    public _Muscle[] muscles;

    public bool Right;
    public bool Left;

    public Rigidbody2D rbRightForWalk;
    public Rigidbody2D rbRightMidForWalk;
    public Rigidbody2D rbLeftForWalk;
    public Rigidbody2D rbLeftMidForWalk;

    public Vector2 WalkRightVector;
    public Vector2 WalkLeftVector;

    private float MoveDelayPointer;
    public float MoveDelay;

    private void Update()
    {
        foreach (_Muscle muscle in muscles)
        {
            muscle.ActivateMuscle();
        }

        if (Input.GetKey(KeyCode.D))
        {
            Right = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Left = true;
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            Left = false;
            Right = false;
        }

        while(Right == true && Left == false && Time.time > MoveDelayPointer)
        {
            Invoke("Step1Right", 0f);
            Invoke("Step2Right", 0.085f);
            MoveDelayPointer = Time.time + MoveDelay;
        }

        while (Left == true && Right == false && Time.time > MoveDelayPointer)
        {
            Invoke("Step1Left", 0f);
            Invoke("Step2Left", 0.085f);
            MoveDelayPointer = Time.time + MoveDelay;
        }
    }

    public void Step1Right()
    {
        rbRightForWalk.AddForce(WalkRightVector, ForceMode2D.Impulse);
        rbLeftForWalk.AddForce(WalkRightVector * -0.5f, ForceMode2D.Impulse);
        rbLeftMidForWalk.AddForce(WalkRightVector * -0.5f, ForceMode2D.Impulse);
        rbRightMidForWalk.AddForce(WalkRightVector, ForceMode2D.Impulse);
    }

    public void Step2Right()
    {
        rbRightForWalk.AddForce(WalkRightVector * -0.5f, ForceMode2D.Impulse);
        rbLeftForWalk.AddForce(WalkRightVector, ForceMode2D.Impulse);
        rbLeftMidForWalk.AddForce(WalkRightVector, ForceMode2D.Impulse);
        rbRightMidForWalk.AddForce(WalkRightVector * -0.5f, ForceMode2D.Impulse);
    }

    public void Step1Left()
    {
        rbRightForWalk.AddForce(WalkLeftVector, ForceMode2D.Impulse);
        rbLeftForWalk.AddForce(WalkLeftVector * -0.5f, ForceMode2D.Impulse);
        rbLeftMidForWalk.AddForce(WalkLeftVector * -0.5f, ForceMode2D.Impulse);
        rbRightMidForWalk.AddForce(WalkLeftVector, ForceMode2D.Impulse);
    }

    public void Step2Left()
    {
        rbRightForWalk.AddForce(WalkLeftVector * -0.5f, ForceMode2D.Impulse);
        rbLeftForWalk.AddForce(WalkLeftVector, ForceMode2D.Impulse);
        rbLeftMidForWalk.AddForce(WalkLeftVector, ForceMode2D.Impulse);
        rbRightMidForWalk.AddForce(WalkLeftVector * -0.5f, ForceMode2D.Impulse);
    }
}

[System.Serializable]

public class _Muscle
{
    public Rigidbody2D bone;
    public float restRotation;
    public float force;

    public void ActivateMuscle()
    {
        bone.MoveRotation(Mathf.LerpAngle(bone.rotation, restRotation, force * Time.deltaTime));
    }
}