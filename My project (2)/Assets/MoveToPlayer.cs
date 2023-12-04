using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    
    public GameObject player;
    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
        playerMovement = player.GetComponentInParent<PlayerMovement>();
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = (playerMovement.speed) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position,step );
    }
}
