using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField]
    private float speed, maxLifeTime, damage = 1;

    float lifeTime = 0;

    Vector3 direction;

    bool isMove = false;

    SpriteRenderer sprite;
    void Start()
    {
        //Fire(Vector3.right);
        //sprite = GetComponentInChildren<SpriteRenderer>();
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

    public void Fire(Vector3 direction)//????? ???????????? ???? ??????? ???? ???????? ??????
    {
        this.direction = direction.normalized;
        isMove = true;

        float directionAngle = GetSpriteAngleDirection(direction);
        sprite.gameObject.transform.eulerAngles = new Vector3(0, 0, directionAngle);
    }

    public void Death()//??????????? ????? ????????????? ????????
    {
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;

        Damageble damageble = gameObject.GetComponent<Damageble>();

        if (damageble != null)
            damageble.Damage(damage);//???? ????? ? ?????? ??????? ???????? ???? ?? ??????? ????


        Death();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        Damageble damageble = gameObject.GetComponent<Damageble>();

        if (damageble != null)
            damageble.Damage(damage);

        Death();
    }
    float GetSpriteAngleDirection(Vector3 direction)
    {
        float directionAngle = Vector2.Angle(Vector2.right, direction);
        sprite = GetComponentInChildren<SpriteRenderer>();

        if (direction.y < 0)
        {
            directionAngle *= -1;
        }

        return directionAngle;
    }
}
