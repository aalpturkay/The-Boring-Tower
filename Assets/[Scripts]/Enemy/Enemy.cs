using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType;
    private int _maxHealth;
    private int _currentHealth;
    private int _takenDamage;

    private void Start()
    {
        _maxHealth = enemyType.maxHealth;
        _currentHealth = enemyType.currentHealth;
        _takenDamage = enemyType.takenDamage;
    }

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(_takenDamage);
    }

    private void TakeDamage(int damageTaken)
    {
        _currentHealth -= damageTaken;
        if (_currentHealth < 0)
        {
            gameObject.SetActive(false);
        }
    }
}