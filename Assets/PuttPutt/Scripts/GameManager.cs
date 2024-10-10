using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    preview,
    playing,
    end
}

public class GameManager : MonoBehaviour
{
    static public GameManager manage;

    public GameState state;

    public int score_counter;

    public GameObject preview_camera;
    
    // Start is called before the first frame update
    void Awake()
    {
        manage = this;

        state = GameState.preview;
     
        score_counter = 0;
        
        preview_camera.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.preview)
        {
            preview_camera.transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                preview_camera.SetActive(false);

                state = GameState.playing;
            }
        }

    }

    public void ScoreIncrease()
    {
        score_counter++;
        GameUI.upkeep.UpdateScore();
    }
}
