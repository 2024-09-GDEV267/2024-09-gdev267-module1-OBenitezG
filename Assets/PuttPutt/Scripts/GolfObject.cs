using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfObject : MonoBehaviour
{
    public GameObject golfball;
    private Rigidbody golfballRB;

    public LayerMask floor;
    public GameObject mouseTest;
    private Vector3 aimPos;

    [Header("Set in Inspector")]
    public float velocityMult = 8f;

    [Header("Set Dynamically")]
    public bool aimingMode;

    // Start is called before the first frame update
    void Start()
    {
        golfballRB = golfball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = golfball.transform.position;
        Debug.Log(golfballRB.velocity);

        if (!aimingMode) return;

        // Ray Cat mouse to game world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, floor))
        {
            Vector3 rayPos = raycastHit.point;
            aimPos = Vector3.Lerp(Camera.main.transform.position, rayPos, 0.2f);
        }

        //aimPos = Vector3.Lerp(golfball.transform.position, aimPos, 0.5f);

        float maxMagnitude = this.GetComponent<SphereCollider>().radius;

        //change to only after
        if (aimPos.magnitude > maxMagnitude)
        {
            aimPos.Normalize();
            aimPos *= maxMagnitude;
        }

        aimPos.y = golfball.transform.position.y;

        mouseTest.transform.position = aimPos;

        if (Input.GetMouseButtonUp(0))
        {
            golfballRB.velocity = -aimPos * velocityMult;
        }

    }

    private void OnMouseEnter()
    {
        print("Slingshot:OnMouseEnter()");
    }


    private void OnMouseExit()
    {
        print("Slingshot:OnMouseExit()");
    }

    private void OnMouseDown()
    {
        aimingMode = true;

    }

}
