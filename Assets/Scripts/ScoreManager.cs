using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public TMP_Text scoreText;

    int score = 0;


    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Seagulls pleased: " + score.ToString();
    }


    public void AddPoint()
    {
        score += 1;
        scoreText.text = "Seagulls pleased: " + score.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
