using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public Text scoreText;

    private float score;
    private GameObject[] buckets;

    // Start is called before the first frame update
    void Start()
    {
        buckets = GameObject.FindGameObjectsWithTag("Bucket");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "0";
        for(int i = 0; i < buckets.Length; i++)
        {
            buckets[i].SetActive(true);
        }
    }
}
