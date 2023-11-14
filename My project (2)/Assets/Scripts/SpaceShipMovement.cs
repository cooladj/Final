using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    public float pitchPower, rollPower, yawPower, enginePower;
    public bool throttle => Input.GetKey(KeyCode.Space);
    private float activeRoll, activePitch, activeYaw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (throttle)
        {
            transform.position += transform.forward * enginePower * Time.deltaTime;
            activePitch = Input.GetAxisRaw("Vertical") * pitchPower * Time.deltaTime;
            activeRoll = Input.GetAxisRaw("Horizontal") * rollPower * Time.deltaTime;
             activePitch = Input.GetAxisRaw("Yaw") * yawPower * Time.deltaTime;
            transform.Rotate(activePitch * pitchPower + Time.deltaTime, activeYaw * yawPower * Time.deltaTime,
                -activeRoll * rollPower * Time.deltaTime, Space.Self);
        }
        else
        {
            
            transform.position += transform.forward * enginePower/2 * Time.deltaTime;
            activePitch = Input.GetAxisRaw("Vertical") * pitchPower/2 * Time.deltaTime;
            activeRoll = Input.GetAxisRaw("Horizontal") * rollPower/2 * Time.deltaTime;
             activePitch = Input.GetAxisRaw("Yaw") * yawPower * Time.deltaTime;
            transform.Rotate(activePitch * pitchPower + Time.deltaTime, activeYaw * yawPower * Time.deltaTime,
                -activeRoll * rollPower * Time.deltaTime, Space.Self);
        
        }
    }
}
