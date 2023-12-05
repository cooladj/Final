using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockToPlayer : MonoBehaviour
{
    public float speed;
    private GameObject target;
    public int Damage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        float step = (speed* 1.5f) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position,step );
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= 2)
        {
            Destroy(gameObject);
        }
    }
}
