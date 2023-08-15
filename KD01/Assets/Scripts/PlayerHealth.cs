using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;

    private float isHealth = 5f;
    private int health = 0;

    public HealthBar healthBar;

    public GameObject lose;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            lose.SetActive(true);
            Time.timeScale = 0;
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    private void Update()
    {
       isHealth -= Time.deltaTime;
        if (isHealth <= 0)
        {
            if(currentHealth <= 100)
            {
                currentHealth += health;
                isHealth = 5;
            }

            if(currentHealth > 100)
            {
                currentHealth = 100;
            }
           
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("quai"))
        {
            takeDamage(2);
        }
    }

    public void HoiMau()
    {
       health += 1;
       Time.timeScale = 1;
    }
}
