using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] int upgradeCost = 50;
    private float fireSpeed =1f;
    public Mesh[] meshes;
    private MeshFilter meshFilter;
    private int nowMesh = 0;
    Tower tower;

    private void Awake()
    {
        tower = GetComponent<Tower>();
        meshFilter = GetComponent<MeshFilter>();
    }
    private void Update()
    {
        
    }
    public void ClickUpgrade()
    { 
        Bank bank = FindAnyObjectByType<Bank>();
        if (bank.CurrentBalance>= upgradeCost)
        {
            nowMesh += 1;
            fireSpeed += 0.5f;
            meshFilter.sharedMesh = meshes[nowMesh];
            var emmisionModule = projectileParticle.emission;
            emmisionModule.rateOverTime = fireSpeed;
            upgradeUI.SetActive(false);
            bank.Withdraw(upgradeCost);
        }
        
    }
    private void OnMouseDown()
    {
        tower.OpenUpgradeUI();
    }
    public void OpenUpgradeUI()
    {
        if (nowMesh >=meshes.Length-1) return;
        upgradeUI.SetActive(true);
    }
    public void CloseUpgradeUI()
    {
        upgradeUI.SetActive(false);
    }
}
