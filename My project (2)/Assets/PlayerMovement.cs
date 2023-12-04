using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [FormerlySerializedAs("sphere")] public GameObject playerShip;
    public Animator animator;
    public Animator playerShipSphereAnimator;
    public CharacterController controller;
    public float speed = 36f;
    Vector3 velocity;
    public float booster = 2f;
    public bool atTop;

    private void Awake()
    {
    }

    void Start()
    {
        atTop = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool rPress = Input.GetKeyDown(KeyCode.R);
        Vector3 move = transform.right * x + -transform.forward * 1;
        if (!atTop)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerShipSphereAnimator.Play("MoveRight");
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                playerShipSphereAnimator.Play("MoveLeft");
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                playerShipSphereAnimator.Play("CounterMoveRight");
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                playerShipSphereAnimator.Play("CounterMoveLeft");
            }

        }

        if (atTop)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerShipSphereAnimator.Play("MoveLeft");
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                playerShipSphereAnimator.Play("MoveRight");
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                playerShipSphereAnimator.Play("CounterMoveLeft");
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                playerShipSphereAnimator.Play("CounterMoveRight");
            }  
        }


        if (Input.GetKey(KeyCode.Space))

        {
            controller.Move(move * (speed * 2) * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        controller.Move(velocity * Time.deltaTime);
    

        if ( rPress && (!atTop))
        {
            atTop = true;
            
            animator.Play("ShipRotate");
            
        }

        if ( rPress && atTop)
        {
            atTop = false;
            animator.Play("CounterRotate");
        }
    }
}