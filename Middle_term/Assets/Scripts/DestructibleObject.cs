using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour, IDamageable
{
    
    public float MaxHealth = 100.0f;

    private float currenthealth;
    public float CurrentHealth { get { return currenthealth; }  }

    private void Awake()
    {
        currenthealth = MaxHealth;
    }

    void Update()
    {
        if (currenthealth <= 0.0f)
        {

            Destroy(gameObject);

        }

    }
    public void TakeDamage(float damage)
    {
        currenthealth -= damage;

    }
}
