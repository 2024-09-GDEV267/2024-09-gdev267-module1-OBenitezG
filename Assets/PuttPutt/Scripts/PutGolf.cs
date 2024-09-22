using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutGolf : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

    }

    // Each physics step..
    void FixedUpdate()
    {


    }

}

