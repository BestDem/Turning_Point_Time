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
    private MovementController movementController;
    private SoundManager soundManager;
    private bool isDeath => currentHealth <= 0;

    private void Start()
    {
        soundManager = GetComponent<SoundManager>();
        movementController = GetComponent<MovementController>();
        currentHealth = maxHealth;
        healthBar.GetDamageHealthBar(currentHealth, maxHealth);
    }

    public void SpawnPlayer()
    {
        soundManager.PlaySongByIndex(3);
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
        {
            movementController.SetCanMove(false);
            soundManager.PlaySongByIndex(3);
            EventDeath?.Invoke();
        }

    }
}
