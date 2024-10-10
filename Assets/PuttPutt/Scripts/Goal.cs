using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPuttPutt : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "GolfBall")
        {

            Rigidbody golfballRB = other.gameObject.GetComponent<Rigidbody>();

            if (golfballRB.IsSleeping())
            {
                //Debug.Log("win");
                GameManager.manage.state = GameState.end;
            }

        }

    }

}
