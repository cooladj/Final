using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollison : MonoBehaviour
{
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
            // todo Make a method on the heath canvas to remove Health and have it take in a float/int marking the Damage
            // rockToPlayer.Damage;
        } 
    }
}
