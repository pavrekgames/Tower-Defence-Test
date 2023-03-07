using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    protected Transform target;

    [Header("Attributes")]
    public int health = 100;
    [SerializeField] protected int maxHealh = 100;
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected int pointsIndex = 0;
    [SerializeField] protected int prize = 50;

    [Header("Ememy UI")]
    [SerializeField] protected Image healthBar;

    public static event Action OnSubstractedLive;
    public static event Action OnKilledEnemy;

    #region Private Methods
    void Start()
    {
        target = EnemyPoints.points[0];
    }

    private void OnEnable()
    {
        health = maxHealh;
        target = EnemyPoints.points[0];
        pointsIndex = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            GameManager.playerLives--;
            GameManager.enemiesAmount--;
            OnKilledEnemy?.Invoke();
            OnSubstractedLive?.Invoke();
            gameObject.SetActive(false);
        }
    }
    #endregion

    #region Protected Methods
    protected void MoveEnemy(Vector3 direction)
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }

    protected void GetNextPoint(float distance)
    {
        if (distance <= 0.2f)
        {
            pointsIndex++;
            target = EnemyPoints.points[pointsIndex];
        }
    }

    protected void EnemyDeath()
    {
        if (health <= 0)
        {
            GameManager.money += prize;
            GameManager.enemiesAmount--;
            OnKilledEnemy?.Invoke();
            gameObject.SetActive(false);
        }
    }

    protected void HealthBar()
    {
        healthBar.fillAmount = health / maxHealh;
    }
    #endregion

    #region Public Methods
    public void ReceiveDamage(int damage)
    {
        health -= damage;
    }
    #endregion 
}
