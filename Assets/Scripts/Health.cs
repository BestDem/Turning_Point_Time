using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHealth;
    [SerializeField] private UnityEvent EventDeath;
    private float currentHealth;
    private bool isDeath => currentHealth <= 0;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.GetDamageHealthBar(currentHealth, maxHealth);
    }

    public void SpawnPlayer()
    {
        currentHealth = maxHealth;
        healthBar.GetDamageHealthBar(currentHealth, maxHealth);
    }

    public void ResetHP(float hp)
    {
        currentHealth += Mathf.Abs(hp);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.GetDamageHealthBar(currentHealth, maxHealth);
    }

    public void GetDamage(float damage)
    {
        currentHealth -= Mathf.Abs(damage);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.GetDamageHealthBar(currentHealth, maxHealth);
        Debug.Log(currentHealth + "осталось хп");

        if (isDeath)
            EventDeath?.Invoke();

    }
}
