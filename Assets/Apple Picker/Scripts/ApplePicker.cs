using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header ("Inscribed")]
    public GameObject basketPrefab;
    public int number_baskets = 3;
    public float basket_bottom_y = -14f;
    public float basket_spacing_y = 2f;

    public List<GameObject> basketList;

    
    void Start()
    {
        basketList = new List<GameObject>();

        for (int i = 0; i < number_baskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basket_bottom_y + (basket_spacing_y * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed()
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject apple in appleArray)
        {
            Destroy(apple);
        }

        int basketIndex = basketList.Count - 1;

        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }

    }

}
