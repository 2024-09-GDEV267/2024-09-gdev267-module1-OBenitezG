using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI upkeep;

    [Header("Dynamic")]
    private int score;
    public Text readyCheck;
    public Text uiLevel;
    public Text uiScore;

    // Start is called before the first frame update
    void Start()
    {
        upkeep = this;
        score = GameManager.manage.score_counter;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.manage.state != GameState.preview)
        {
            readyCheck.text = "";
        }

        uiScore.text = "Score:" + score.ToString("#,0");

        if (GameManager.manage.state == GameState.end)
        {
            readyCheck.text = "YOU WIN!";
        }
    }

    public void UpdateScore()
    {
        score = GameManager.manage.score_counter;
    }
}
