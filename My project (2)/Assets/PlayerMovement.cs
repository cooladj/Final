using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    public float speed = 36f;
    Vector3 velocity;
    public float booster = 2f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + -transform.forward * 1;
        if (x == 1)
        {
            animator.Play("MoveRight");
        }

        if (x == -1)
        {
            animator.Play("MoveLeft");
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
        if (Input.GetKeyDown(KeyCode.R) && transform.rotation.z == 180)
        {
        }

        if (Input.GetKeyDown(KeyCode.R) && transform.rotation.z == 0)
        {
        }
    }
}