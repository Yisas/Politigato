using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text scoreText;
    public float time;

    private bool quit = false;
    private float score;
    private float timer;

    void Start()
    {
        score = GManager.maxScore;
        timer = time;
        scoreText.text = "Puntuación final: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && !quit)
        {
            quit = true;
            timer = time;
            scoreText.text = "Puntuación final: " + (score / 10000) + "\nUps, se te devaluó!";
        }
        else if(timer <= 0 && quit)
        {
            Application.Quit();
        }
    }
}
