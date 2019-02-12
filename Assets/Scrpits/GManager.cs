using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;
    public Animator blackoutPanelAnimator;
    public float gameTime;

    private int score = 0;
    public static int maxScore = 0;
    private float timer;

    private GameObject[] buckets;
    private GameObject[] powerUps;

    // Start is called before the first frame update
    void Start()
    {
        buckets = GameObject.FindGameObjectsWithTag("Bucket");
        powerUps = GameObject.FindGameObjectsWithTag("Powerup");

        timer = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = ((int)(timer / 60)) + ":" + (int)(timer % 60);

        if(timer < 0)
        {
            blackoutPanelAnimator.SetTrigger("fade");
        }
    }

    public void Score()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        if(score > maxScore)
        {
            maxScore = score;
        }

        score = 0;
        scoreText.text = "0";
        for(int i = 0; i < buckets.Length; i++)
        {
            buckets[i].SetActive(true);
        }
        for (int i = 0; i < powerUps.Length; i++)
        {
            powerUps[i].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            blackoutPanelAnimator.SetTrigger("fade");
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(2);
    }
}
