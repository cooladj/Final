using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockToPlayer : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public float Damage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position,step );
    }
}
