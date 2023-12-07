using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public Camera Camera;

    // Start is called before the first frame update
    private Vector3 screenBounds;
    private float objectWidth;
    private float objectHeight;


    // Use this for initialization
    void Start()
    {
      
        objectWidth = transform.GetComponentInChildren<MeshRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponentInChildren<MeshRenderer>().bounds.extents.y; //extents = size of height / 2
       
    }

    // Update is called once per frame

        void LateUpdate()
        {
            Vector3 viewportPosition = Camera.WorldToViewportPoint(transform.position);

            // Clamping within the viewport space (0 to 1)
            viewportPosition.x = Mathf.Clamp(viewportPosition.x, 0, 1);
            viewportPosition.y = Mathf.Clamp(viewportPosition.y, 0, 1);

            // Optional: Adjust for Z if necessary, based on your game's requirements

            // Convert the clamped position back to world space
            Vector3 clampedWorldPosition = Camera.ViewportToWorldPoint(viewportPosition);

            // Set the object's position, maintaining its original Z if needed
            transform.position = new Vector3(clampedWorldPosition.x, clampedWorldPosition.y, transform.position.z);
        }

    }

