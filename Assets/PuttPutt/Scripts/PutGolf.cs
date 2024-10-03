using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutGolf : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float velocityMult = 8f;

    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public GameObject[] RespawnPoint;
    public bool aimingMode;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {


    }

    // Each physics step..
    void FixedUpdate()
    {


    }

    private void OnMouseEnter()
    {
        //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }


    private void OnMouseExit()
    {
        //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
    }

    private void OnMouseDown()
    {
        aimingMode = true;

        rb.isKinematic = true;

    }
}

