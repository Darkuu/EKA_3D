using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    [SerializeField] private float hitInterval = 0.5f;
    [SerializeField] private int xpToGive = 20;
    public UnityEvent OnDeath;

    private float lastHitTime = 0;
    private int currentHealth;

    private Animator animator;

    private bool isDead = false;

    public bool IsDead
    {
        get { return isDead; }
    }
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerWeapon") && !isDead && Time.time - lastHitTime > hitInterval)
        {
            TakeDamage(10);
        }
    }

    private void TakeDamage(int damage)
    {
        lastHitTime = Time.time;
        currentHealth -= damage;
        Debug.Log("Current health: " + currentHealth);
        
        if (currentHealth > 0)
        {
            animator.SetTrigger("Hit");
        }
        else
        {
            LevelManager.instance.GiveXP(xpToGive);
            animator.SetTrigger("Death");
            OnDeath.Invoke();
            isDead = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
