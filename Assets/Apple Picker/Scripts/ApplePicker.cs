using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [Header ("Inscribed")]
    public GameObject basketPrefab;
    public int number_baskets = 3;
    public float basket_bottom_y = -14f;
    public float basket_spacing_y = 2f;

    
    void Start()
    {
        for (int i = 0; i < number_baskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basket_bottom_y + (basket_spacing_y * i);
            tBasketGO.transform.position = pos;
        }
    }

}
