using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            float distance = Vector3.Distance(transform.position, target.position);

            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            if (distance <= 0.2f)
            {
                target.GetComponent<Enemy>().ReceiveDamage(damage);
                gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
