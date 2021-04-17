using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Type", menuName = "Enemy Type")]
public class EnemyType : ScriptableObject
{
    public int currentHealth;
    public int maxHealth;
    public int takenDamage;
}
