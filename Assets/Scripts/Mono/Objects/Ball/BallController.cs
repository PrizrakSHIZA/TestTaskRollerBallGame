using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Force = 10f;
    
    //if mobile must lay down flat, as on table
    private bool isflat = true;
    private Rigidbody rigit;

    void Start()
    {
        rigit = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 tilt = Input.acceleration;
        //rotate acceleration input to have 0 on 
        if (isflat)
            tilt = Quaternion.Euler(90, 0, 0) * tilt;

        //Adding additional force to ball, avoiding Y-axis 
        rigit.AddForce(new Vector3(tilt.x, 0, tilt.z) * Force);
    }
}
