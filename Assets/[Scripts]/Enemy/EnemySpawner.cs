using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] [Range(.1f, 30f)] private float spawnTimer = 1f;
    [SerializeField] [Range(0, 50)] private int poolSize = 5;
    [SerializeField] private GameObject enemy;

    private GameObject[] _pool;

    private void Awake()
    {
        PopulatePool();
    }

    private void Start()
    {
        StartCoroutine(CreateEnemyIE());
    }

    private void ActivateEnemies()
    {
        foreach (var enemyInPool in _pool)
        {
            if (!enemyInPool.activeInHierarchy)
            {
                enemyInPool.SetActive(true);
                return;
            }
        }
    }

    IEnumerator CreateEnemyIE()
    {
        while (true)
        {
            ActivateEnemies();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private void PopulatePool()
    {
        _pool = new GameObject[poolSize];
        for (int i = 0; i < _pool.Length; i++)
        {
            _pool[i] = Instantiate(enemy, parent: transform);
            _pool[i].SetActive(false);
        }
    }
}