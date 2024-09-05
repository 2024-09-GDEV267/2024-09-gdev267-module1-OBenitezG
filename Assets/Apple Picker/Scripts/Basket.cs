using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse_pos_2D = Input.mousePosition;

        mouse_pos_2D.z = -Camera.main.transform.position.z;

        Vector3 mouse_pos_3d = Camera.main.ScreenToWorldPoint(mouse_pos_2D);

        Vector3 pos = this.transform.position;
        pos.x = mouse_pos_3d.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collided_with = collision.gameObject;

        if (collided_with.CompareTag("Apple") )
        {
            Destroy(collided_with );
        }
    }
}
