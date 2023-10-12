using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class B_WayPoints : MonoBehaviour
{
    [SerializeField] private GameObject buildTowerUI;
    [SerializeField] GameObject towerPrefab;
    [SerializeField] GameObject rockTowerPrefab;
    [SerializeField] bool isPlaceable;
    [SerializeField] bool isBuildUIActive = false;

    private void OnMouseDown()
    {
        if(isPlaceable)
        {
            OpenBuildTowerUI();
        }
    }
    public void BuildBombTower()
    {
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        buildTowerUI.SetActive(false);
        isPlaceable = false;
    }
    public void BuildRockTower()
    {
        Instantiate(rockTowerPrefab, transform.position, Quaternion.identity);
        buildTowerUI.SetActive(false);
        isPlaceable = false;
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

