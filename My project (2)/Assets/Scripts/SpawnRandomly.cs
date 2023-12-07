using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnRandomly : MonoBehaviour
{
    public float radius;
    public GameObject asteroid;
    [SerializeField] private float delay=2;
    public int RockSpawnLocation;
    
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < RockSpawnLocation; i ++)
        {
            StartCoroutine(SpawnDelay());
        }
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