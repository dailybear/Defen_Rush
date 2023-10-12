using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] private GameObject buildTowerUI;
    [SerializeField] GameObject towerPrefab;
    [SerializeField] GameObject rockTowerPrefab;
    [SerializeField] bool isBuildUIActive = false;
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
