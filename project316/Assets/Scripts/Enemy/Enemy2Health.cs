using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Health : MonoBehaviour
{
    public float enemyHealth = 100f;
    EnemyAI enemy;
    void Start()
    {
        enemy = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            enemyHealth = 0;
        }
    }

    public void ReduceHealth(float reduceHealth)
    {
        enemyHealth -= reduceHealth;
        if (!enemy.isDead)
        {
            enemy.Hurt();
        }

        if (enemyHealth <= 0)
        {
            enemy.DeadAnim();
            Dead();
        }
    }

    void Dead()
    {
        enemy.canAttack = false;
        Destroy(gameObject, 4f);
    }
}

