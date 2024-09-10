using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exercises : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject basketPrefab;
    public GameObject appleTreePrefab;

    [Header("Exercises")]
    public bool Exercise_1 = false;
    public bool Exercise_2 = false;
    public bool Exercise_3_4 = false;
    public bool Exercise_5_6_7 = false;

    [Header("Difficulty")]
    public int wave_counter = 0;
    public float speed_modifier;
    public float delay_modifier;

    private int number_baskets = 3;
    private float basket_bottom_y = -14f;
    private float basket_spacing_y = 2f;

    private List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        if (Exercise_1)
        {
            for (int counter = 0; counter < 10; counter++)
            {
                GameObject box = Instantiate<GameObject>(cubePrefab);

                Vector3 boxPosition = box.transform.position;

                boxPosition.x = counter * 2;

                box.transform.position = boxPosition;
            }
        }
        
        else if (Exercise_2)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int counter = 0; counter < 8; counter++)
                {
                    GameObject box = Instantiate<GameObject>(cubePrefab);

                    Vector3 boxPosition = box.transform.position;

                    boxPosition.x = counter * 2;
                    boxPosition.y = row * 2;

                    box.transform.position = boxPosition;
                }
            }

        }

        else if (Exercise_3_4)
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

        else if (Exercise_5_6_7)
        {
            appleTreePrefab.SetActive(true);

            basketList = new List<GameObject>();

            for (int i = 0; i < number_baskets; i++)
            {
                GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
                Vector3 pos = Vector3.zero;
                pos.y = basket_bottom_y + (basket_spacing_y * i);
                tBasketGO.transform.position = pos;
                basketList.Add(tBasketGO);
            }

            DifficultyIncrease();
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DifficultyIncrease()
    {
        speed_modifier = wave_counter * 1.5f;
        delay_modifier = wave_counter * 0.05f;

        appleTreePrefab.GetComponent<AppleTree>().setSpeed(speed_modifier);
        appleTreePrefab.GetComponent<AppleTree>().setAppleDelay(1 - delay_modifier);
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
            SceneManager.LoadScene("_Scene_Exercises");
        }

    }
}
