using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_EnemyMove : MonoBehaviour
{
    [SerializeField] List<B_WayPoints> path = new List<B_WayPoints>();
    [SerializeField] float waitTime = 1f;
    private void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach(B_WayPoints waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
