using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollison : MonoBehaviour
{
    public HealthBarController healthBarController;

    // Start is called before the first frame update
    void Start()
    {
        
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
            Debug.Log("hitplayer");
            // todo Make a method on the heath canvas to remove Health and have it take in a float/int marking the Damage
            // rockToPlayer.Damage;
        }
        
    }

 
}
