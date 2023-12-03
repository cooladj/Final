using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomly : MonoBehaviour
{
    public float radius;
    public GameObject asteroid;
    [SerializeField] private float delay=2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(delay);
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * radius;
        Instantiate(asteroid, randomPoint, Quaternion.identity);
        StartCoroutine(SpawnDelay());
    }
}