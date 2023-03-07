using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsObjectPool : MonoBehaviour
{
    public static BulletsObjectPool instance;

    public List<GameObject> bullets = new List<GameObject>();

    public GameObject bulletToPool;
    public int bulletAmount;
    public Transform bulletsParent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        CreateBullets();
    }

    void CreateBullets()
    {
        GameObject newBullet;

        for (int i = 0; i < bulletAmount; i++)
        {
            newBullet = Instantiate(bulletToPool, bulletsParent);
            newBullet.SetActive(false);
            bullets.Add(newBullet);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }
        return null;
    }
}
