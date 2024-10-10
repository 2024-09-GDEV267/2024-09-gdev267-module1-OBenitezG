using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{

    private Rigidbody golfballRB;
    public Vector3 respawnPoint;

    [Header("Aiming Field")]
    public GameObject mouseTest;
    public LayerMask floor;

    public Vector3 direction;
    public float strength;

    private Vector3 aimPos;

    [Header("Play State")]
    public bool aiming;
    public bool moving;
    public bool idle;

    [Header("Set in Inspector")]
    public float velocityMult = 180f;

    void Start()
    {
        golfballRB = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
        idle = true;
    }

    void Update()
    {
        if (GameManager.manage.state == GameState.preview || GameManager.manage.state == GameState.end) return;

        if (aiming)
        {
            mouseTest.SetActive(true);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, floor))
            {
                aimPos = raycastHit.point;
                aimPos.y = transform.position.y;
            }

            float distanceGolfBall = Vector3.Distance(transform.position, aimPos);

            if (distanceGolfBall > 4f)
            {
                Vector3 chain = (aimPos - transform.position).normalized;
                aimPos = transform.position + chain * 4f;
            }

            mouseTest.transform.position = aimPos;

            if (Input.GetMouseButtonUp(0))
            {
                aiming = false;
                mouseTest.SetActive(false);

                direction = (aimPos - transform.position).normalized;

                strength = Vector3.Distance(transform.position, aimPos);

                golfballRB.AddForce(-direction * strength * velocityMult);

                GameManager.manage.ScoreIncrease();

                idle = false;
                moving = true;

            }
        }

        else if (moving)
        {
            if (golfballRB.IsSleeping())
            {
                moving = false;
                idle = true;
            }

        }

        else if (idle)
        {
            if (respawnPoint != transform.position)
            {
                respawnPoint = transform.position;
            }
        }

        
    }

    public void OutofBounds()
    {
        golfballRB.Sleep();
        transform.position = respawnPoint;
    }

    private void OnMouseDown()
    {
        if (moving) return;

        aiming = true;
    }

}
