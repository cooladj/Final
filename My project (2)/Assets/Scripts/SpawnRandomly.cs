using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnRandomly : MonoBehaviour
{
    public float radius=50;
    public GameObject asteroid;
    [SerializeField] private float delay=2;
    public int RockSpawnLocation;
    [SerializeField] private float gasDelay = 4;
    public GameObject Gas;
    public int gasSpawnRadius;
    public int CoinDelay;
    public int coinSpawnLocation;
    public GameObject Coins;
    public int coinSpawnradius;
    
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < RockSpawnLocation; i ++)
        {
            
            StartCoroutine(SpawnDelay());
        }

        for (int i = 0; i < coinSpawnLocation; i++)
        {
            StartCoroutine(PointDelay());
        }

        StartCoroutine(GasSpawnDelay());
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
    private IEnumerator GasSpawnDelay()
    {
        yield return new WaitForSeconds(gasDelay);
        Vector3 randomPoint = transform.position+Random.insideUnitSphere* gasSpawnRadius;
        
        Instantiate(Gas, randomPoint, Quaternion.identity);
        StartCoroutine(GasSpawnDelay());
    
    }

    private IEnumerator PointDelay()
    {
        yield return new WaitForSeconds(CoinDelay);
        Vector3 randomPoint = transform.position+Random.insideUnitSphere* coinSpawnradius;

        Instantiate(Coins, randomPoint, Quaternion.identity);
        StartCoroutine(PointDelay());



    }
}