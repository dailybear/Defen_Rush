using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab; // �� ������
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 7f;
    [SerializeField] [Range(0f, 50f)] int poolSize = 10;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool(); // ������ �� �̸� �� ���ӿ�����Ʈ�� ������ pool �迭�� ����
    }
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool() // �� �������� Ǯ�� ä��
    {
        pool = new GameObject[poolSize]; // 10

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform); // �� �������� ������ ��Ȱ��ȭ �ؼ� �־��
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool() // �����ؼ� ��Ȱ��ȭ �� �� �� ���ӿ�����Ʈ Ȱ��ȭ
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false) // ���̶�Ű â���� �迭 ���� ������Ʈ�� ��Ȱ��ȭ�� ��
            {
                pool[i].SetActive(true); // ���ӿ�����Ʈ Ȱ��ȭ �ؼ� ����
                return;
            }
        }
    }

    IEnumerator SpawnEnemy() // �� ����
    {
        while(true) 
        {
            EnableObjectInPool(); // �� ���ӿ�����Ʈ�� Ȱ��ȭ ��
            yield return new WaitForSeconds(spawnTimer); // 1�� �� ����
        }
    }
}
