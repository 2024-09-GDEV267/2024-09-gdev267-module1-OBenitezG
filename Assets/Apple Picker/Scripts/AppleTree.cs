using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AppleTree : MonoBehaviour
{

    [Header("Inscribed")]
    public GameObject applePrefab;

    public float speed = 10f;

    public float left_and_right_edge = 25f;
    public float change_direction_chance = 0.02f;
    public float apple_delay = 1f;

    void Start()
    {

        Invoke("DropApple", 2f);

    }

    void DropApple()
    {

        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", apple_delay);

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;


        if (pos.x < -left_and_right_edge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > left_and_right_edge)
        {
            speed = -Mathf.Abs(speed);
        }
            
    }

    private void FixedUpdate()
    {

        if (Random.value < change_direction_chance)
        {
            speed *= -1;
        }

    }

    public float getSpeed()
    {
        return speed;
    }

    public void setSpeed(float newSpeed)
    {
        speed += newSpeed;
    }

    public float getAppleDelay()
    {
        return apple_delay;
    }

    public void setAppleDelay(float newAppleDelay)
    {
        apple_delay = newAppleDelay;
    }

}
