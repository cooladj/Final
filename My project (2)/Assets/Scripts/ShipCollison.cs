using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ShipCollison : MonoBehaviour
{
    [SerializeField]private HealthBarController healthBarController;
   [SerializeField] private FuelBarController fuelBarController;
   [SerializeField] private AudioManger audioManger;
   [SerializeField] private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManger.Play("BackGround");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<RockToPlayer>(out RockToPlayer rockToPlayer))
        {
            healthBarController.TakeDamage(rockToPlayer.Damage);
            audioManger.Play("AsteroidBreak");
            // todo Make a method on the heath canvas to remove Health and have it take in a float/int marking the Damage
            // rockToPlayer.Damage;
        }

        if (other.gameObject.TryGetComponent<Gas>(out Gas gas))
        {
           audioManger.Play("GasRefill"); 
            fuelBarController.IncreaseFuelByPercentage(gas.GasIncrease);
        }

        if (other.gameObject.TryGetComponent<Coins>(out Coins coins))
        {
            audioManger.Play("Coin");
            scoreManager.IncrementScore(coins.pointIncrease);
        }
        
    }

 
}
