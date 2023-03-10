using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudUI : MonoBehaviour
{
    [Header("Canvases")]
    [SerializeField] private Canvas hudCanvas;
    [SerializeField] private Canvas upgradesCanvas;
    [SerializeField] private Canvas redTurretUpgradesCanvas;
    [SerializeField] private Canvas pauseCanvas;

    [Header("HUD Texts")]
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI enemyAmountText;

    [Header("References")]
    [SerializeField] UpgradesUI upgradesUI;

    #region Private Methods
    private void Start()
    {
        Enemy.OnSubstractedLive += UpdateLivesText;
        Enemy.OnKilledEnemy += UpdateMoneyText;
        Enemy.OnKilledEnemy += UpdateEnemyAmountText;
        WaveSpawner.OnSpawnedEnemy += UpdateEnemyAmountText;
        Node.OnTurretPlaced += UpdateMoneyText;
        UpgradesUI.OnTurretUpgraded += UpdateMoneyText;
    }

    private void UpdateLivesText()
    {
        livesText.text = GameManager.playerLives.ToString();
    }

    private void UpdateMoneyText()
    {
        moneyText.text = GameManager.money.ToString();
    }

    private void UpdateEnemyAmountText()
    {
        enemyAmountText.text = GameManager.enemiesAmount.ToString();
    }
    #endregion

    #region Public Methods
    public void ShowUpgrades()
    {
        upgradesCanvas.enabled = true;
        redTurretUpgradesCanvas.enabled = true;
        hudCanvas.enabled = false;
        upgradesUI.DisplayRedTurretStats();
        Time.timeScale = 0;
    }

    public void PauseGame()
    {
        hudCanvas.enabled = false;
        pauseCanvas.enabled = true;
        Time.timeScale = 0;
    }
    #endregion
}
