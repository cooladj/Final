using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    
    public GameObject target;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
        playerController = target.GetComponentInParent<PlayerController>();
        Debug.Log(playerController);
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = (playerController.speed*1.3f) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position,step );
    }
}
