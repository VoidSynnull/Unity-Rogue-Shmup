using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "SO/Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }
    [SerializeField] float attackValue;
    public float AttackValue { get => attackValue; private set => attackValue = value; }
    [SerializeField] float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

}
