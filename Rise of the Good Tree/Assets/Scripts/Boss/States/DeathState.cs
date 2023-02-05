using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    NextLevel nextLevel;

    Animator animator;

    bool flag = false;
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Callback(BossStateBehavior bossStateBehavior)
    {
        if (!flag)
        {
            FindObjectOfType<AudioManager>().Play("BossDeath");
            flag = true;
            animator.SetTrigger("isDead");
            StartCoroutine(BossDeadEffect());
        }
    }

    IEnumerator BossDeadEffect()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(nextLevel.EndLevelEffect());
    }
}
