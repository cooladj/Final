using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject GameMangerObject;
    public Image healthBar;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = GameMangerObject.GetComponent<GameManager>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        healthBar.fillAmount = healthPercentage;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if(currentHealth == 0)
        {
            gameManager.OutOfLives();
            
        }

    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar() ;
    }

    void GameOver()
    {
       
        Debug.Log("Game Over!");
       
    }
}
