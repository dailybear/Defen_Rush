using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_WayPoints : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceable;

    private void OnMouseDown()
    {
        Debug.Log("Click");
        if(isPlaceable)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}

