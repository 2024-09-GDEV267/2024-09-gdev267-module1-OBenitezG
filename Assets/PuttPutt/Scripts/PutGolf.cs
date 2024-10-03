using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutGolf : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float velocityMult = 8f;

    [Header("Set Dynamically")]
    public GameObject[] RespawnPoint;
    public bool aimingMode;

    public GameObject mouseTest;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        Debug.Log(rb.velocity);

        if (!aimingMode) return;

        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;

            Vector3 mousePos2D = Input.mousePosition;
            mousePos2D.z = -Camera.main.transform.position.z;
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

            Vector3 mouseDelta = mousePos3D - transform.position;

            float maxMagnitude = this.GetComponent<SphereCollider>().radius;

            if (mouseDelta.magnitude > maxMagnitude)
            {
                mouseDelta.Normalize();
                mouseDelta *= maxMagnitude;
            }

            Debug.Log(mouseDelta);

            Vector3 projPos = transform.position + mouseDelta;
            mouseTest.transform.position = projPos;

            rb.velocity = -mouseDelta * velocityMult;

        }

    }

    // Each physics step..
    void FixedUpdate()
    {

    }

    private void OnMouseEnter()
    {
        //print("Slingshot:OnMouseEnter()");
    }


    private void OnMouseExit()
    {
        //print("Slingshot:OnMouseExit()");
    }

    private void OnMouseDown()
    {
        aimingMode = true;

    }
}

