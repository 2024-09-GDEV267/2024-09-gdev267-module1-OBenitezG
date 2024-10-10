using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI upkeep;

    [Header("Dynamic")]
    private int score;
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
        uiScore.text = "Score:" + score.ToString("#,0");
    }

    public void UpdateScore()
    {
        score = GameManager.manage.score_counter;
    }
}
