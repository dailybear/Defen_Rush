using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMover3 : MonoBehaviour
{

    [SerializeField] List<Waypoint> path = new List<Waypoint>(); // �ν����Ϳ����� ������ ���
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Animator anim;
    SkeletonAttack sAttack;
    Enemy enemy;



    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        sAttack = GetComponent<SkeletonAttack>();
        anim = GetComponent<Animator>();
    }

    void FindPath()
    {
        path.Clear(); // ��θ� ã���� ������ ���� ���� �� �� ��� �߰�

        GameObject parent = GameObject.FindGameObjectWithTag("Path3");

        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();

            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }

    }


    void ReturnToStart()
    {
        transform.position = path[0].transform.position; // ���ӿ�����Ʈ�� �н� ���� ��ġ��
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }

    }
}
