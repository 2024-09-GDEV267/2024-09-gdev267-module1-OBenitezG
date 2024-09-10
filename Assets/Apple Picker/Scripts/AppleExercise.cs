using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleExercise : MonoBehaviour
{
    public static float bottomY = -20f;

    void Update()
    {
      
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            Exercises apScript = Camera.main.GetComponent<Exercises>();

            apScript.AppleMissed();
        }

    }
}
