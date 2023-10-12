using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab; // 적 프리팹
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 7f;
    [SerializeField] [Range(0f, 50f)] int poolSize = 10;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool(); // 실행할 때 미리 적 게임오브젝트를 생성해 pool 배열에 저장
    }
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool() // 적 프리팹을 풀에 채움
    {
        pool = new GameObject[poolSize]; // 10

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform); // 적 프리팹을 생성해 비활성화 해서 넣어둠
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool() // 생성해서 비활성화 해 둔 적 게임오브젝트 활성화
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false) // 하이라키 창에서 배열 내의 오브젝트가 비활성화일 때
            {
                pool[i].SetActive(true); // 게임오브젝트 활성화 해서 리턴
                return;
            }
        }
    }

    IEnumerator SpawnEnemy() // 적 스폰
    {
        while(true) 
        {
            EnableObjectInPool(); // 적 게임오브젝트를 활성화 해
            yield return new WaitForSeconds(spawnTimer); // 1초 후 리턴
        }
    }
}
