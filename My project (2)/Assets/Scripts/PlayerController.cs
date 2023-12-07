using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    public Animator playerShipSphereAnimator;
    public CharacterController controller;
    public float speed = 36f;
    Vector3 velocity;
   

    private void Awake()
    {
       
    }

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x +transform.forward * -1 + transform.up *y;
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerShipSphereAnimator.Play("MoveRight");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerShipSphereAnimator.Play("MoveLeft");
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            playerShipSphereAnimator.Play("CounterMoveRight");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            playerShipSphereAnimator.Play("CounterMoveLeft");
        }

        controller.Move(move* speed* Time.deltaTime);
        

        // if(Input.GetKeyDown(KeyCode.S))
        // {
        //     playerShipSphereAnimator.Play("MoveDown");
        // }
        // if (Input.GetKeyUp(KeyCode.S))
        // {
        //     playerShipSphereAnimator.Play("MoveDownCounter");
        // }
        //
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     playerShipSphereAnimator.Play("Moveup");
        // }
        //
        // if (Input.GetKeyUp(KeyCode.W))
        // {
        //     playerShipSphereAnimator.Play("MoveupCounter");
        // }


    }
}