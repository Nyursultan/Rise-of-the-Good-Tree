using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed, maxLifeTime, damage = 1;

    float lifeTime = 0;

    Vector3 direction;

    bool isMove = false;
    void Start()
    {
        //Fire(Vector3.right);
    }

    void Update()
    {
        if (isMove)
        {
            lifeTime += Time.deltaTime;
            transform.position += direction * speed * Time.deltaTime;
        }

        if (lifeTime >= maxLifeTime)
        {
            Death();
        }
    }

    public void Fire(Vector3 direction)//после срабатывания этой функции пуля начинает летать
    {
        this.direction = direction.normalized;
        isMove = true;
    }

    public void Death()//срабатывает когда заканчивается лайфтайм
    {
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;

        Damageble damageble = gameObject.GetComponent<Damageble>();

        if (damageble != null)
            damageble.Damage(damage);//если попал в объект который получает урон он наносит урон
        

        Death();
    }
}
