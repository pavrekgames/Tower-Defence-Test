using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class Node : MonoBehaviour
{
    private TurretFactory turretFactory;

    [Header("Node Attributes")]
    [SerializeField] private Renderer nodeRenderer;
    [SerializeField] private Color startColor;
    [SerializeField] private Color hoverColor;

    [Header("Turret om Node")]
    public GameObject turretToBuild;
    private Turret turret;
    [SerializeField] private GameObject currentTurret;
    [SerializeField] private Vector3 offSet;

    public static event Action OnTurretPlaced;

    void Start()
    {
        turretFactory = TurretFactory.instance;
        nodeRenderer = GetComponent<Renderer>();
        startColor = nodeRenderer.material.color;
        turret = turretToBuild.GetComponent<Turret>();
    }

    private void OnMouseEnter()
    {
        turretFactory.selectedNode = this;
        turretToBuild = turretFactory.currentTurret;
        turret = turretToBuild.GetComponent<Turret>();

        if (currentTurret == null && Time.timeScale == 1)
        {
            nodeRenderer.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        nodeRenderer.material.color = startColor;
        turretFactory.selectedNode = null;
    }

    private void OnMouseDown()
    {
        if (currentTurret == null && GameManager.money >= turret.cost && Time.timeScale == 1)
        {
            turretToBuild = turretFactory.currentTurret;
            GameObject newTurret = Instantiate(turretToBuild, transform.position + offSet, transform.rotation);
            currentTurret = newTurret;
            TurretDecorate(currentTurret);
            GameManager.money -= turret.cost;
            OnTurretPlaced?.Invoke();
        }
    }

    private void TurretDecorate(GameObject turret)
    {
        Turret turretToDecorate = turret.GetComponent<Turret>();

        if (turretToDecorate.turretData.turretName == turretFactory.currentRedTurretUpgrade.turretName)
        {
            turretToDecorate.range = turretFactory.currentRedTurretUpgrade.range;
        }
        else
        {
            turretToDecorate.range = turretFactory.currentGreenTurretUpgrade.range;
        }
    }
}
