using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Score : MonoBehaviour
{
    [SerializeField]
    int PPC = 5;
    [SerializeField]
    int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;



    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void AddScore()
    {
        currentScore = PPC + currentScore;
        scoreText.text = currentScore.ToString();

    }
}
