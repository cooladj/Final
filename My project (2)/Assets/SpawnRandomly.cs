using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomly : MonoBehaviour
{
    public float radius;
    public GameObject asteroid;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * radius;
        Instantiate(asteroid, randomPoint, Quaternion.identity);
    }
}
