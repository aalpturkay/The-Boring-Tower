using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerType towerType;
    [SerializeField] private ParticleSystem particleSystem;
    private int _towerRange;
    private Transform _enemy;


    public bool InstantiateTower(Tower tower, Vector3 position, Transform parentTransform)
    {
        Instantiate(tower, position, Quaternion.identity, parentTransform);
        return true;
    }

    private void Start()
    {
        _towerRange = towerType.range;
        _enemy = FindObjectOfType<Enemy>().transform;
    }

    private void Update()
    {
        FindClosestEnemy();
        AimEnemy();
    }

    private void FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float minDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (var enemy in enemies)
        {
            var distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy.transform;
            }
        }

        _enemy = closestEnemy;
    }

    private void AimEnemy()
    {
        var enemyPosition = _enemy.position;
        float enemyDistance = Vector3.Distance(enemyPosition, transform.position);
        transform.DOLookAt(enemyPosition, .1f);
        if (enemyDistance < _towerRange)
        {
            SetParticleShoot(true);
        }
        else
        {
            SetParticleShoot(false);
        }
    }

    private void SetParticleShoot(bool isActive)
    {
        var emission = particleSystem.emission;
        emission.enabled = isActive;
    }
}