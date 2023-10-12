using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] private GameObject buildTowerUI;
    [SerializeField] GameObject towerPrefab;
    [SerializeField] GameObject rockTowerPrefab;
    [SerializeField] bool isBuildUIActive = false;
    [SerializeField] int bombTowerCost = 75;
    [SerializeField] int rockTowerCost = 45;
    public bool IsPlaceable { get { return isPlaceable; } }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            OpenBuildTowerUI();
        }
    }

    public void BuildBombTower()
    {
        buildTowerUI.SetActive(false);
        Bank bank = FindObjectOfType<Bank>();
        if(bank.CurrentBalance >=bombTowerCost)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            bank.Withdraw(bombTowerCost);
            
            isPlaceable = false;
        }
       
    }

    public void BuildRockTower()
    {
        buildTowerUI.SetActive(false);
        Bank bank = FindObjectOfType<Bank>();
        if(bank.CurrentBalance >= rockTowerCost)
        {
            Instantiate(rockTowerPrefab, transform.position, Quaternion.identity);
            bank.Withdraw(rockTowerCost);
            
            isPlaceable = false;
        }
       
    }

    public void OpenBuildTowerUI()
    {
        buildTowerUI.SetActive(true);
    }
    public void CloseBuildTowerUI()
    {
        buildTowerUI.SetActive(false);
    }
}
