using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;
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
        Debug.Log("업그레이드");
        nowMesh += 1;
        meshFilter.sharedMesh = meshes[nowMesh];
        upgradeUI.SetActive(false);
    }
    private void OnMouseDown()
    {
        tower.OpenUpgradeUI();
    }
    public void OpenUpgradeUI()
    {
        if (nowMesh >= 2) return;
        upgradeUI.SetActive(true);
    }
    public void CloseUpgradeUI()
    {
        upgradeUI.SetActive(false);
    }
}
