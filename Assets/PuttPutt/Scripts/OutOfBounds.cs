using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GolfBall")
        {
            GolfBall golfBall = other.GetComponent<GolfBall>();

            if (golfBall != null)
            {
                golfBall.OutofBounds();

            }
        }
    }
}
