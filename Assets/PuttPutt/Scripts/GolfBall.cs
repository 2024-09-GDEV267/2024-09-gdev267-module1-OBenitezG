using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{

    private Rigidbody golfballRB;

    [Header("Aiming Field")]
    public GameObject mouseTest;
    public LayerMask floor;

    public Vector3 direction;
    public float strength;

    private Vector3 aimPos;

    [Header("Set in Inspector")]
    public float velocityMult = 180f;

    // Start is called before the first frame update
    void Start()
    {
        golfballRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, floor))
        {
            aimPos = Vector3.Lerp(Camera.main.transform.position, raycastHit.point, 0.2f);
        }

        aimPos.y = transform.position.y;

        mouseTest.transform.position = aimPos;

        if (Input.GetMouseButtonUp(0))
        {
            direction = (aimPos - transform.position).normalized;

            strength = Mathf.Clamp(Vector3.Distance(transform.position, aimPos), 0.2f, 4f);

            golfballRB.AddForce(-direction * strength * velocityMult);

        }

    }
}
