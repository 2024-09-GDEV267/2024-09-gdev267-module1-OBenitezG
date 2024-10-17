using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket_exercise : MonoBehaviour
{
    public Exercises exercise;
    public ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {

        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();

        GameObject exerciseGO = GameObject.Find("Main Camera");
        exercise = exerciseGO.GetComponent<Exercises>();
    }

    // Update is called once per frame
    void Update()
    {
        if (exercise.Exercise_3_4)
        {
            Vector3 mouse_pos_2D = Input.mousePosition;

            mouse_pos_2D.z = -Camera.main.transform.position.z;

            Vector3 mouse_pos_3d = Camera.main.ScreenToWorldPoint(mouse_pos_2D);

            Vector3 pos = this.transform.position;

            pos.x = mouse_pos_3d.x;
            pos.y = mouse_pos_3d.y;
            this.transform.position = pos;
        }
        else
        {
            Vector3 mouse_pos_2D = Input.mousePosition;

            mouse_pos_2D.z = -Camera.main.transform.position.z;

            Vector3 mouse_pos_3d = Camera.main.ScreenToWorldPoint(mouse_pos_2D);

            Vector3 pos = this.transform.position;

            pos.x = mouse_pos_3d.x;
            this.transform.position = pos;
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collided_with = collision.gameObject;

        if (collided_with.CompareTag("Apple"))
        {
            Destroy(collided_with);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }

}
