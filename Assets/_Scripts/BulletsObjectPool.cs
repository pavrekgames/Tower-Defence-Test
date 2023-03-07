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

    #region Private Methods
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
    private void Start()
    {
        CreateBullets();
    }

    private void CreateBullets()
    {
        GameObject newBullet;

        for (int i = 0; i < bulletAmount; i++)
        {
            newBullet = Instantiate(bulletToPool, bulletsParent);
            newBullet.SetActive(false);
            bullets.Add(newBullet);
        }
    }
    #endregion

    #region Public Methods
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
    #endregion
}
