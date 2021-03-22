using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xaxis;
    float yaxis;
    public float multiplier = 1 ;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        xaxis = Input.GetAxis("Horizontal");
        yaxis = Input.GetAxis("Vertical");

        rb.AddForce(Vector3.right * xaxis * multiplier);
        rb.AddForce(Vector3.forward * yaxis * multiplier);
    }

}
