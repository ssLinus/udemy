using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] wallPrefab;
    public GameObject boomPrefab;
    public GameObject enemyPrefab;
    public float interval = 1.5f;  // ���� �ð�����
    public float range = 3;
    float term;

    void Start()
    {
        term = interval;  // ���ۺ��� ���� �ϳ� ������ ����
    }

    void Update()
    {
        term += Time.deltaTime;
        if (term >= interval)
        {
            Vector3 pos = transform.position;
            pos.y += Random.Range(-range, range);
            int wallType = Random.Range(0, wallPrefab.Length);
            Instantiate(wallPrefab[wallType], pos, transform.rotation);
            if (Random.Range(0, 2) == 0)
                Instantiate(boomPrefab);
            if (Random.Range(0, 3) == 0)
                Instantiate(enemyPrefab, pos, transform.rotation);
                term -= interval;
        }
    }
}
