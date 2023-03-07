using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesUI : MonoBehaviour
{
    [Header("Upgrades Canvases")]
    [SerializeField] private Canvas upgradesPanelCanvas;
    [SerializeField] private Canvas redTurretUpgradesCanvas;
    [SerializeField] private Canvas greenTurretUpgradesCanvas;
    [SerializeField] private Canvas hudCanvas;

    [Header("Turret Stats")]
    [SerializeField] private TextMeshProUGUI turretName;
    [SerializeField] private TextMeshProUGUI turretLevelValue;
    [SerializeField] private TextMeshProUGUI damageValue;
    [SerializeField] private TextMeshProUGUI rangeValue;
    [SerializeField] private TextMeshProUGUI bulletSpeedValue;

    public TurretData[] turretsUpgrades;
    [SerializeField] TurretFactory turretFactory;

    public static event Action OnTurretUpgraded;

    #region Private Methods
    private void Start()
    {
        turretFactory = TurretFactory.instance;
    }

    private void SetStatsValues(TurretData turretData)
    {
        turretName.text = turretData.turretName.ToString();
        turretLevelValue.text = turretData.level.ToString();
        damageValue.text = turretData.damage.ToString();
        rangeValue.text = turretData.range.ToString();
        bulletSpeedValue.text = turretData.bulletSpeed.ToString();
    }
    #endregion

    #region Public Methods
    public void HideUpgrades()
    {
        upgradesPanelCanvas.enabled = false;
        redTurretUpgradesCanvas.enabled = false;
        greenTurretUpgradesCanvas.enabled = false;
        hudCanvas.enabled = true;
        Time.timeScale = 1;
    }

    public void UpgradeRedTurret(TurretData turretUpgrade)
    {
        if (GameManager.money >= turretUpgrade.upgradeCost && turretFactory.currentRedTurretUpgrade.level < turretUpgrade.level)
        {
            turretFactory.currentRedTurretUpgrade = turretUpgrade;
            GameManager.money -= turretUpgrade.upgradeCost;
            OnTurretUpgraded?.Invoke();
            DisplayRedTurretStats();
        }
    }

    public void UpgradeGreenTurret(TurretData turretUpgrade)
    {
        if (GameManager.money >= turretUpgrade.upgradeCost && turretFactory.currentGreenTurretUpgrade.level < turretUpgrade.level)
        {
            turretFactory.currentGreenTurretUpgrade = turretUpgrade;
            GameManager.money -= turretUpgrade.upgradeCost;
            OnTurretUpgraded?.Invoke();
            DisplayGreenTurretStats();
        }
    }

    public void DisplayRedTurretStats()
    {
        redTurretUpgradesCanvas.enabled = true;
        greenTurretUpgradesCanvas.enabled = false;

        SetStatsValues(turretFactory.currentRedTurretUpgrade);
    }

    public void DisplayGreenTurretStats()
    {
        redTurretUpgradesCanvas.enabled = false;
        greenTurretUpgradesCanvas.enabled = true;

        SetStatsValues(turretFactory.currentGreenTurretUpgrade);
    }
    #endregion
}
